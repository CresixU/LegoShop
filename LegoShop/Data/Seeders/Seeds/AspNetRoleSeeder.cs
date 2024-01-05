using LegoShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LegoShop.Data.Seeders.Seeds
{
    public class AspNetRoleSeeder : IEntitySeeder
    {
        private readonly ApplicationDbContext _context;

        public AspNetRoleSeeder(ApplicationDbContext context)
        {

            _context = context;
        }

        public async Task Seed()
        {
            var x = _context.Roles.Count();
            var y = _context.Roles.Any();
            if (x <= 1)
            {
                var data = new List<IdentityRole>()
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("Moderator"),
                    new IdentityRole("User")
                };

                await _context.AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
