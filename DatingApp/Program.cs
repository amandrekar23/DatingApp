using DatingApp.Data;
using Microsoft.EntityFrameworkCore;
using DatingApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add db context class
var config = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
IServiceCollection serviceCollection = builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(config.DbConn);
});

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
