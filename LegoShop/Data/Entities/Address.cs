using Microsoft.EntityFrameworkCore;

namespace LegoShop.Data.Entities
{
    [Owned]
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
