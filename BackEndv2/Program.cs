using BackEndv2.Data;
using BackEndv2.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add API for everyone to use
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Add Database
builder.Services.AddDbContext<PerfumeDetailContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseProduct")));

// Add Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Add life cycle DI
builder.Services.AddScoped<IPerfumeRepositories, PerfumeRepositories>();

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
