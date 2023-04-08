using API.Data;
using API.Data.Repositories;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddDbContext<ApplicationDbConext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")
            // , x => x.UseDateOnlyTimeOnly()
               
            ));

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddScoped<IChildInterface, ChildRepository>();

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
 app.UseRouting();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthorization();

app.MapControllers();

app.Run();
