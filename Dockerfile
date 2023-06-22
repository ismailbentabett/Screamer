FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY Screamer.WebApi/Screamer.WebApi.csproj Screamer.WebApi/
COPY Screamer.Application/Screamer.Application.csproj Screamer.Application/
COPY Screamer.Domain/Screamer.Domain.csproj Screamer.Domain/
COPY Screamer.Identity/Screamer.Identity.csproj Screamer.Identity/
COPY Screamer.Infrastructure/Screamer.Infrastructure.csproj Screamer.Infrastructure/
COPY Screamer.Presistance/Screamer.Presistance.csproj Screamer.Presistance/
RUN dotnet restore Screamer.WebApi/Screamer.WebApi.csproj
COPY . .
WORKDIR "/src/Screamer.WebApi"
RUN dotnet build "Screamer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Screamer.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use SQL Express as the base image
FROM mcr.microsoft.com/mssql/server:2019-latest AS sqlbase
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=

# Create and restore the SQL database
FROM build AS restoredb
WORKDIR /src/Screamer.Presistance
RUN dotnet ef database update -c ApplicationDbContext

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Screamer.WebApi.dll"]
