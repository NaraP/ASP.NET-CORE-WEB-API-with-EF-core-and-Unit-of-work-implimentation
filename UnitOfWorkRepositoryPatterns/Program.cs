using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RespositoryLayer.Repository.EmployeeRepository;
using RespositoryLayer.UnitOfWork;
using ServiceLayer.Exceptions;
using ServiceLayer.Filters;
using ServiceLayer.IServices;
using ServiceLayer.Services;
using UnitOfWorkRepositoryPatterns;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDBContext>(
               x => x.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));

builder.Services.AddTransient(typeof(IEmployeeService), typeof(EmployeeService));
builder.Services.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));

//Database
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter>();
    options.Filters.Add(typeof(AppExceptionFilter));
    options.Filters.Add(typeof(ValidateModelAttribute));
    options.CacheProfiles.Add("Default", new CacheProfile() { NoStore = true });
}).AddNewtonsoftJson();

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
