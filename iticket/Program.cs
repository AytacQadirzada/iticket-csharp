using Iticket.Business.Profiles;
using Iticket.Business.Service.Implementations;
using Iticket.Business.Service.Interfaces;
using Iticket.Business.Token.Implementations;
using Iticket.Business.Token.Interfaces;
using Iticket.Core.Entities;
using Iticket.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMemoryCache();

/////////
///


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = builder.Configuration.GetSection("Jwt:audience").Value,
        ValidIssuer = builder.Configuration.GetSection("Jwt:issuer").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:securityKey").Value)),
    };
});

///
/////////

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

/////////
////

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IMailSendService, MailSendService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductEventService, ProductEventService>();
builder.Services.AddScoped<IHallService, HallService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IVenuesService, VenuesService>();
builder.Services.AddScoped<IUserService, UserService>();


var tempProvider = builder.Services.BuildServiceProvider();
var loggerFactory = tempProvider.GetRequiredService<ILoggerFactory>();

builder.Services.AddMapperService(loggerFactory);
////
//////////

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});
var app = builder.Build();




////
///


app.UseCors("AllowAll");



////

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//////////
///
app.UseRouting();

///
/////////

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//////////
///

app.MapControllers();

app.Run();
