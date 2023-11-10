using EmployeeService.Commands;
using EmployeeService.Models;
using EmployeeService.Queries;
using EmployeeService.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using static FluentValidation.DependencyInjectionExtensions;
using EmployeeService.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<EmployeeCreateDtoValidator>();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IDepartmentCommandsRepository, DepartmentCommandsRepository>();
builder.Services.AddScoped<IDepartmentQueriesRepository, DepartmentQueriesRepository>();
builder.Services.AddScoped<IJobPostCommandsRepository, JobPostCommandsRepository>();
builder.Services.AddScoped<IJobPostQueriesRepository, JobPostQueriesRepository>();
builder.Services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();
builder.Services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();
builder.Services.AddScoped<IEmployeeCommands, EmployeeCommands>();
builder.Services.AddScoped<IEmployeeQueries, EmployeeQueries>();
builder.Services.AddScoped<IDepartmentCommands, DepartmentCommands>();
builder.Services.AddScoped<IDepartmentQueries, DepartmentQueries>();
builder.Services.AddScoped<IJobPostCommands, JobPostCommands>();
builder.Services.AddScoped<IJobPostQueries, JobPostQueries>();

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
