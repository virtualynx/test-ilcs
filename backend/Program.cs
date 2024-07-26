using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "myCors",
        policy  =>{
            policy.WithOrigins("*");
            policy.AllowAnyHeader();
        }
    );

    // options.AddPolicy(
    //     "AllowAllOrigins",
    //     builder =>
    //     {
    //         builder.AllowAnyOrigin();
    //         builder.AllowAnyHeader();
    //         builder.AllowAnyMethod();
    //     }
    // );
});

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<_DbContext>(opt =>
    opt.UseMySQL("server=localhost;database=test;user=root;password=")
);

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

app.UseCors("myCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
