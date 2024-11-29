using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MeParkAPI.Areas.Identity.Data;
using MeParkAPI.Services;
using MeParkAPI.Services.UnitOfWork;
using MeParkAPI.Services.Repository;
using MeParkAPI.Models;
using MeParkAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MeParkAPIContextConnection") ?? throw new InvalidOperationException("Connection string 'MeParkAPIContextConnection' not found.");

builder.Services.AddDbContext<MeParkAPIContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MeParkAPIContext>();

// Add services to the container.
builder.Services.AddScoped<ApplicationUserService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<ParkingService>();
builder.Services.AddScoped<ParkingSpaceService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.RegisterMapsterConfiguration();

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

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
