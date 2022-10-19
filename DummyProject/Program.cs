using DummyProject.Models;
using DummyProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LoginContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("loanCon")));

//builder.Services.AddScoped<IRepo<int,Customer>, CustomerDBService>();
//builder.Services.AddScoped<IRepo<string, Login>, LoginRepo>();
//builder.Services.AddScoped<ILogin, LoginService>();
//builder.Services.AddScoped<ITokenService, TokenService>();



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
