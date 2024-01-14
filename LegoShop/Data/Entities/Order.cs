using System.ComponentModel;

namespace LegoShop.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [DisplayName("Data zamówienia")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Cena")]
        public decimal TotalPrice { get; set; }
        [DisplayName("ID Produktu")]
        public virtual Product Product { get; set; }
        [DisplayName("Nazwa produktu")]
        public Guid ProductId { get; set; }
        [DisplayName("ID użytkownika")]
        public virtual ApplicationUser User { get; set; }
        [DisplayName("Użytkownik tworzący produkt")]
        public string UserId { get; set; }
        [DisplayName("Numer statusu")]
        public virtual OrderStatus OrderStatus { get; set; }
        public int OrderStatusId { get; set; }


    }
}
