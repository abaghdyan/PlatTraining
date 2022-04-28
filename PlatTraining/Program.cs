using PlatTraining;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration
//    .AddEnvironmentVariables();
//    //.AddJsonFile("something.json", false, true);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationOptions(builder.Configuration);
builder.Services.AddPlatDbContext(builder.Configuration.GetConnectionString("PlatDb"));
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
