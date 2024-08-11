using Source.Models;
using Source.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ISynchronizationService, SynchronizationService>();
builder.Services.AddTransient<IBus, MockBus>();
builder.Services.AddTransient<IConsumer<BusResponseModel>, BusConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();