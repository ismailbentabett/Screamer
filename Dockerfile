# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY Screamer.WebApi/Screamer.WebApi.csproj Screamer.WebApi/
COPY Screamer.Application/Screamer.Application.csproj Screamer.Application/
COPY Screamer.Domain/Screamer.Domain.csproj Screamer.Domain/
COPY Screamer.Identity/Screamer.Identity.csproj Screamer.Identity/
COPY Screamer.Infrastructure/Screamer.Infrastructure.csproj Screamer.Infrastructure/
COPY Screamer.Presistance/Screamer.Presistance.csproj Screamer.Presistance/
RUN dotnet restore Screamer.WebApi/Screamer.WebApi.csproj



# Copy the source code and build the project
COPY . .
WORKDIR /src/Screamer.WebApi
RUN dotnet build -c Release -o /app/build


WORKDIR /src

# Install the dotnet-ef tool
RUN mkdir /tools
RUN dotnet tool install dotnet-ef --tool-path /tools
ENV PATH="${PATH}:/tools"

# Run Entity Framework Core migrations and update the database
RUN dotnet ef migrations add NewMigration -p Screamer.Presistance/Screamer.Presistance.csproj -s Screamer.WebApi/Screamer.WebApi.csproj 
#RUN dotnet ef database update -p Screamer.Presistance/Screamer.Presistance.csproj -s Screamer.WebApi/Screamer.WebApi.csproj 


# Publish stage
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS final
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# Generate a self-signed certificate
RUN apt-get update && apt-get install -y openssl
RUN openssl req -x509 -newkey rsa:4096 -nodes -keyout localhost.key -out localhost.crt -subj "/CN=localhost" -addext "subjectAltName = DNS:localhost"

# Set up HTTPS
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
ENV ASPNETCORE_HTTPS_PORT=5001
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/localhost.crt
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/app/localhost.key
ENV ConnectionStrings__ScreamerDbConnection="Server=db;Database=Screamer;User Id=sa;Password=YourPassword;MultipleActiveResultSets=true;TrustServerCertificate=True"



# Copy the published files from the publish stage
COPY --from=publish /app/publish .



# Start the application
ENTRYPOINT ["dotnet", "Screamer.WebApi.dll"]
