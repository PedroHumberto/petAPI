using Microsoft.EntityFrameworkCore;
using petrgAPI.Data;
using petrgAPI.Services;
using petrgAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Depedency Injection
builder.Services.AddScoped<AddressService, AddressService>();
builder.Services.AddScoped<IPetService, PetService>();



builder.Services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
