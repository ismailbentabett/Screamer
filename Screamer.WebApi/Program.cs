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
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});
builder.Services.AddSingleton<PresenceTracker>();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
            .Json
            .ReferenceLoopHandling
            .Ignore;
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc; // Ensure dates are serialized in UTC
        options.SerializerSettings.ContractResolver =
            new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(); // Optional: Use camelCase naming convention for properties
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; // Optional: Ignore null values during serialization
        options.SerializerSettings.PreserveReferencesHandling = Newtonsoft
            .Json
            .PreserveReferencesHandling
            .None; // Optional: Prevent circular references from being serialized
    });

builder.Services.AddCors(
    o =>
        o.AddPolicy(
            "CorsPolicy",
            builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:4200");
            }
        )
);

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

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<PresenceHub>("hubs/presence");
app.MapHub<MessageHub>("hubs/message");
app.MapHub<PostHub>("hubs/post");
app.MapHub<NotificationHub>("hubs/notification");

app.Run();
