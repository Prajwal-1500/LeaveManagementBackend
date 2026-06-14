using LeaveManagementBackend.Data;
using LeaveManagementBackend.Helper;
using LeaveManagementBackend.Repositories.Implementation;
using LeaveManagementBackend.Repository.Implementation;
using LeaveManagementBackend.Repository.Interfaces;
using LeaveManagementBackend.Services.Implementation;
using LeaveManagementBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LeaveManagementBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
             ));

            var jwtSettings = builder.Configuration
               .GetSection("Jwt")
               .Get<JwtSettings>() ?? throw new Exception("JWT settings not found");

            builder.Services.AddSingleton(jwtSettings);


            var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
            builder.Services.AddScoped<ILeaveService, LeaveService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
