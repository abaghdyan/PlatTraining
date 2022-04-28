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
builder.Services.AddPlatDbContext(builder.Configuration.GetConnectionString("PlatDb"));
builder.Services.AddServices();

var app = builder.Build();

await app.Services.MigrateDBContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
