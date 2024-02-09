


using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RainbowSchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EFConnStr")));

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
