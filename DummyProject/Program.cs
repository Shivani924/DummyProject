using DummyProject.Models;
using DummyProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LoginContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("loanCon")));

//builder.Services.AddScoped<IRepo<int,Customer>, CustomerDBService>();
//builder.Services.AddScoped<IRepo<string, Login>, LoginRepo>();
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IToken, TokenService>();
builder.Services.AddScoped<IRepo<string, Login>, LoginRepo>();
builder.Services.AddScoped<IRepo<int, Customer>, CustomerDBService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
