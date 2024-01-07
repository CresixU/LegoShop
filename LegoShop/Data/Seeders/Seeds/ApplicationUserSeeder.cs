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
            if(!_context.Users.Any()) 
            {
                var users = new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                        UserName = "admin@test.pl",
                        PasswordHash = "AQAAAAIAAYagAAAAEGwXioQ4VrHbqcEegfybG25Gr9Vypqy0Hzqjteoz1k2uEWPRhfl6SXYH+Cp/0v7mWw==",
                        Email = "admin@test.pl",
                        EmailConfirmed = true,
                        Address = new Address(),
                        Id = Guid.NewGuid().ToString()
                    },
                    new ApplicationUser()
                    {
                        UserName = "moderator@test.pl",
                        PasswordHash = "AQAAAAIAAYagAAAAEGwXioQ4VrHbqcEegfybG25Gr9Vypqy0Hzqjteoz1k2uEWPRhfl6SXYH+Cp/0v7mWw==",
                        Email = "moderator@test.pl",
                        EmailConfirmed = true,
                        Address = new Address(),
                        Id = Guid.NewGuid().ToString()
                    }
                };
                await _userManager.AddToRoleAsync(users[0], "Admin");
                await _userManager.AddToRoleAsync(users[1], "Moderator");

                await _context.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}
