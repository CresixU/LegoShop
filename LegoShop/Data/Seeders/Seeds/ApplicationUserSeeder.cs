using LegoShop.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LegoShop.Data.Seeders.Seeds
{
    public class ApplicationUserSeeder : IEntitySeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserSeeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            if(await _context.Database.CanConnectAsync() && !_context.Users.Any()) 
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
                await _userManager.AddToRoleAsync(user, "Admin");
                await _context.SaveChangesAsync();
            }
        }
    }
}
