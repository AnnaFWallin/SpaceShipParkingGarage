using Microsoft.EntityFrameworkCore;
using SpaceshipGarageAPI.Interfaces;
using SpaceshipGarageAPI.RequestHandlers;
using SpaceshipGarageAPI.Data.Repository;
using SpaceshipGarageAPI;
using SpaceshipGarageAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SpaceshipDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddTransient<IRestRequestHandler, RestRequestHandler>();
builder.Services.AddTransient<IParkinglotRepository, ParkinglotRepository>();

builder.Services.AddControllers();
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

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
