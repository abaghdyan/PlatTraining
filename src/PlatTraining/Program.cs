using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using PlatTraining;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("PlatDb"))
    .AddRedis(builder.Configuration.GetConnectionString("Redis"));

builder.Services.AddApplicationOptions(builder.Configuration);
builder.Services.AddPlatMasterDbContext(builder.Configuration.GetConnectionString("PlatDb"));
builder.Services.AddServices();

var app = builder.Build();

await app.Services.MigratePlatMasterDbContextAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    })
    .UseRouting()
    .UseEndpoints(config => config.MapDefaultControllerRoute());

app.Run();
