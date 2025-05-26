using Microsoft.EntityFrameworkCore;
using OldHome.DAL;
using OldHome.Entities;

namespace OldHome.Service
{
    public static class WebApplicationExtension
    {
        public static void InitializeDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDataContext>();
                db.Database.Migrate();
                if (!db.Users.Any())
                {
                    db.Users.Add(new User
                    {
                        UserName = "admin",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
                        PhoneNum = "1234567890",
                        CreatedAt = DateTime.UtcNow,
                        Role = new Role
                        {
                            Name = "super_admin",
                            Description = "超级管理员",
                            CreatedAt = DateTime.UtcNow,
                            Code = "SuperAdmin"
                        },
                        Org = new Org
                        {
                            Name = "管理公司",
                            Address = "管理公司地址",
                            PhoneNum = "1234567890",
                            CreatedAt = DateTime.UtcNow,
                            IsHead = true,
                        }
                    });
                    db.Roles.Add(new Role
                    {
                        Name = "admin",
                        Description = "管理员",
                        CreatedAt = DateTime.UtcNow,
                        Code = "Admin"
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
