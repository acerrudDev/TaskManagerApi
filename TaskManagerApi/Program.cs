using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Data.Context;
using TaskManagerApi.Data.Repositories;
using TaskManagerApi.Interfaces.IRepositories;
using TaskManagerApi.Interfaces.IServices;
using TaskManagerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tareas.db"));

builder.Services.AddScoped<ITaskMgrService, TaskMgrService>();
builder.Services.AddScoped<ITaskMgrRepository, TaskMgrRepository>();

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
