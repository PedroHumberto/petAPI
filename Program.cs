using Microsoft.EntityFrameworkCore;
using PetRGAPI.Data;
using PetRGAPI.Services;
using PetRGAPI.Services.Interfaces;


public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        //SQL
        builder.Services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
        //Automap
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        //Depedency Injection
        builder.Services.AddScoped<AddressService, AddressService>();
        builder.Services.AddScoped<PetGuardianService, PetGuardianService>();
        builder.Services.AddScoped<IPetService, PetService>();


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
    }
}