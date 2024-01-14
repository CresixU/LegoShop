using System.ComponentModel;

namespace LegoShop.Data.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public int ConstId { get; set; }
        [DisplayName("Status")]
        public string Name { get; set; }
        public bool IsImmutable { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
