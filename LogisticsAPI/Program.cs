using LogisticsSystem.Application.Interfaces;
using LogisticsSystem.Application.Services;
using LogisticsSystem.Domain.Interfaces;
using LogisticsSystem.Infrastructure.Persistence;
using LogisticsSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILoadRepository, LoadRepository>();
builder.Services.AddScoped<ILoadService, LoadService>();

builder.Services.AddScoped<IDriverLoadRequestRepository, DriverLoadRequestRepository>();
builder.Services.AddScoped<IDriverLoadRequestService, DriverLoadRequestService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();