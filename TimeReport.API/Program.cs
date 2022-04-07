using Microsoft.EntityFrameworkCore;
using TimeReport.API.Models;
using TimeReport.API.Services;
using TimeReport.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o=>o.SerializerSettings.ReferenceLoopHandling
= Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<TimeReportDbContext>(o => o.UseSqlServer("data source=DESKTOP-JP9EE11;database=ProjektTimeReport;trusted_connection=true"));
builder.Services.AddScoped<IProjectTimeReport<Employee>, EmployeeRepo>();
builder.Services.AddScoped<IProjectRepo<Project>, ProjectRepo>();
builder.Services.AddScoped<ITimeRepRepo<TimeRep>, TimeRepRepo>();



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

app.MapControllers();

app.Run();
