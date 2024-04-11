using BackEndv2.Data;
using BackEndv2.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

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
builder.Services.AddScoped<ICustomerRepositories, CustomerRepositories>();

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();

// Cấu hình CORS middleware
app.UseCors(options => options
    .AllowAnyOrigin() // Chấp nhận tất cả các nguồn
    .AllowAnyHeader() // Chấp nhận tất cả các header
    .AllowAnyMethod()); // Chấp nhận tất cả các phương thức HTTP


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
