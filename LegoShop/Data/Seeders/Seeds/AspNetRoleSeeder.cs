using Microsoft.AspNetCore.Identity;

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
            if (_context.Roles.Count() <= 1)
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
                    new IdentityRole("User")
                };

                await _context.AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
