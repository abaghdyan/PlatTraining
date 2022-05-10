using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using PlatTraining;
using PlatTraining.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("PlatDb"))
    .AddRedis(builder.Configuration.GetConnectionString("Redis"));

builder.Services.AddApplicationOptions(builder.Configuration);
builder.Services.RegisterHubs();
builder.Services.AddAuthenticationLayer(builder.Configuration);
builder.Services.AddSwaggerLayer();

builder.Services.AddPlatMasterDbContext(builder.Configuration.GetConnectionString("PlatMasterDb"));
builder.Services.AddPlatTenantDbContext();
builder.Services.AddServices();

var app = builder.Build();

await app.Services.MigratePlatMasterDbContextAsync();
await app.Services.MigratePlatTenantDbContextAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<TenantResolutionMiddlware>();

app.MapControllers();

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    })
    .UseEndpoints(config => config.MapDefaultControllerRoute());

app.Run();
