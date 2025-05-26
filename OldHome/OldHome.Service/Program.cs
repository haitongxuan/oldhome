using BCrypt.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.Entities;
using OldHome.Service.Endpoints;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OldHome.Service
{
    public class Program
    {
        const string jwtKey = "L9vZfN4xW2q8RmX0jP7cT5sBqMd1KvUg";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDataContext>(options =>
            {
                options.UseSqlite("Data Source=oldhome.db");
            });

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        // 这里是关键点
                        NameClaimType = ClaimTypes.Name,
                        RoleClaimType = ClaimTypes.Role,

                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            builder.Services.AddAuthorization();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            app.InitializeDatabase();

            app.MapGet("/", () => "Hello World!");

            app.MapAuthEndpoints();
            app.MapUserEndpoints();
            app.MapOrgEndpoints();
            app.MapRoleEndpoints();
            app.MapOrgAreaEndpoints();
            app.MapEmergencyContactEndpoints();
            app.MapStaffEndpoints();
            app.MapDepartmentEndpoints();
            app.MapRoomEndpoints();
            app.MapBedEndpoints();
            app.MapMedicineEndpoints();
            app.MapResidentEndpoints();
            app.MapMedicineInventoryEndpoints();

            app.Run();
        }
    }
}
