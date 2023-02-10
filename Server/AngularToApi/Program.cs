using AngularToApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();

//Add ContextDB
builder.Services.AddDbContext<ApplicationDb>(options =>
    options.UseSqlServer(connectionString));

//Add Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(
    option =>
    {
        option.Password.RequiredLength = 6;
        option.Password.RequireDigit=false;
        option.Password.RequireUppercase = false;
        option.Password.RequireLowercase = false;
        option.Password.RequireNonAlphanumeric = false;
        option.Password.RequiredUniqueChars = 0;
      
    }
    ).AddEntityFrameworkStores<ApplicationDb>();

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

//to complete the Identity Operation
app.UseAuthentication();

app.MapControllers();

app.Run();
