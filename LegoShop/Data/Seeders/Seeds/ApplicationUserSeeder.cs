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
                await _context.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}
