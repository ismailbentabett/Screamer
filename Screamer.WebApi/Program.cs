using Screamer.Application;
using Screamer.Identity;
using Screamer.Infrastructure;
using Screamer.Presistance;
using Screamer.WebApi;
using Screamer.WebApi.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresistanceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


builder.Services.AddControllers()   .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints
(
    endpoints =>
    {
        app.MapControllers();

        endpoints.MapControllers();
        endpoints.MapHub<PresenceHub>("hubs/presence");
        endpoints.MapHub<MessageHub>("hubs/message");
        endpoints.MapFallbackToController("Index", "Fallback");
    }
);
app.Run();