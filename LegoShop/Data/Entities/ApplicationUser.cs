using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LegoShop.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Product> Products { get; set; } = new List<Product>();
        public Address Address { get; set; }
    }
}
