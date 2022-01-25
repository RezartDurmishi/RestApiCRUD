using Microsoft.EntityFrameworkCore;
using RestApiCRUD.EmployeeRepository;
using RestApiCRUD.EmployeeRepository;
using RestApiCRUD.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeRepository, PostgreEmployeeRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContextPool<EmployeeContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("employeesDB"))
    );

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
