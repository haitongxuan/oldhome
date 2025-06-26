using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OldHome.BLL;
using OldHome.DAL;
using OldHome.Mapping;
using OldHome.Service.Endpoints;
using OldHome.Service.Interceptors;
using System.Security.Claims;
using System.Text;

namespace OldHome.Service
{
    public class Program
    {
        const string jwtKey = "L9vZfN4xW2q8RmX0jP7cT5sBqMd1KvUg";
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // 在 Program.cs 中更新 DbContext 配置

            builder.Services.AddDbContext<AppDataContext>((serviceProvider, options) =>
            {
                options.UseSqlite("Data Source=oldhome.db").AddInterceptors(new SerialNumberInterceptor());
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

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            builder.Services.AddAuthorization();
            builder.Services.AddScoped<InventoryBLL>();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<BedProfile>();
                cfg.AddProfile<DepartmentProfile>();
                cfg.AddProfile<EmergencyContactProfile>();
                cfg.AddProfile<MedicationOutboundProfile>();
                cfg.AddProfile<MedicationPrescriptionProfile>();
                cfg.AddProfile<MedicineInventoryProfile>();
                cfg.AddProfile<MedicineProfile>();
                cfg.AddProfile<MedicineTransactionLogProfile>();
                cfg.AddProfile<OrgAreaProfile>();
                cfg.AddProfile<OrgProfile>();
                cfg.AddProfile<ResidentProfile>();
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddProfile<StaffProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<FamilyMedicineDeliveryProfile>();
            });

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            await app.InitializeDatabaseAsync();

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
            app.MapMediciationPrescriptionEndpoints();
            app.MapMedicationOutboundEndpoints();

            app.Run();
        }
    }
}
