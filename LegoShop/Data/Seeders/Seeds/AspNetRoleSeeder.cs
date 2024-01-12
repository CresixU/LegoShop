using LegoShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LegoShop.Data.Seeders.Seeds
{
    public class AspNetRoleSeeder : IEntitySeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AspNetRoleSeeder(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync() && await _context.Roles.CountAsync() <= 1)
            {
                var data = new List<IdentityRole>()
                {
                    new IdentityRole() 
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        Id = Guid.NewGuid().ToString()
                    },
                    new IdentityRole()
                    {
                        Name = "User",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        Id = Guid.NewGuid().ToString()
                    }
                };

                await _context.AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
