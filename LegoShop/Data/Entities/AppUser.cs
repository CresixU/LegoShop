using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LegoShop.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public virtual UserRole UserRole { get; set; }
        public string UserRoleId { get; set; }
        public Address Address { get; set; }
    }
}
