using Microsoft.AspNetCore.Identity;

namespace LegoShop.Data.Entities
{
    public class UserRole : IdentityRole
    {
        public List<AppUser> Users { get; set; } = new List<AppUser>();
    }
}