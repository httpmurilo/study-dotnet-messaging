using Microsoft.EntityFrameworkCore;
using study_project.db;
using study_project.messaging.service;
using study_project.repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "test");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProducerCartUpdateService>();
builder.Services.AddSingleton<ICartRepository>();
builder.Services.AddSingleton<IItensRepository>();
builder.Services.AddSingleton<ICustomerRepository>();
builder.Services.AddHostedService<ConsumerService>();


//log
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Logging.ClearProviders().AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
