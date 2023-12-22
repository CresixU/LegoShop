namespace LegoShop.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        
        public virtual AppUser User { get; set; }
        public string UserId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public int OrderStatusId { get; set; }


    }
}
