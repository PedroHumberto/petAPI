using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DB Injection
builder.Services.AddDbContext<UserDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection")));

//Idenity
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
        opt => opt.SignIn.RequireConfirmedEmail = true
    )
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opts => {
    opts.Password.RequiredLength = 7;
});

//--------------------

//Injections
builder.Services.AddScoped<SingUpService, SingUpService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LogoutService, LogoutService>();


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
