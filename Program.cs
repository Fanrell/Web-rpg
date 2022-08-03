using Microsoft.EntityFrameworkCore;
using RPG.Context;
using RPG.Context.Repositories;
using RPG.Context.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRpgSystemRepository, RpgSystemRepository>();
builder.Services.AddControllers();

builder.Services.AddDbContext<RpgDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RpgDatabase")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();