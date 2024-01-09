using LegoShop.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LegoShop.Data.Seeders.Seeds
{
    public class ApplicationUserSeeder : IEntitySeeder
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if(!_context.Users.Any()) 
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@test.pl",
                    NormalizedUserName = "ADMIN@TEST.PL",
                    Email = "admin@test.pl",
                    NormalizedEmail = "ADMIN@TEST.PL",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    Address = new Address(),
                    Id = Guid.NewGuid().ToString()
                };

                user.PasswordHash = new PasswordHasher<ApplicationUser>()
                    .HashPassword(user, "Password12@");

                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
