using MeetingRoom.Repositories;
using MeetingRoom.Services;
using MeetingRooms_Backend.Models;
using MeetingRooms_Backend.Models.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MeetingRoomsContext>(options =>
{
	options.UseSqlServer("Server=.\\SQLExpress;Database=meetingRooms;Trusted_Connection=True;Encrypt=False");
});



// Register the Respositories and add them as dependancy injection
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<User, Role>(options =>
{
	options.Password.RequiredLength = 8;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
	options.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<MeetingRoomsContext>()
			.AddDefaultTokenProviders(); ;




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
