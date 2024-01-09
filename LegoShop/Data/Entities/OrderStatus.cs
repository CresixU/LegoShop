namespace LegoShop.Data.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public int ConstId { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
