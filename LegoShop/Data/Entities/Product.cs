using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LegoShop.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [DisplayName("Nazwa produktu")]
        public string Name { get; set; }
        [DisplayName("Opis produktu")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Typ klocka")]
        public string MosaicType { get; set; }
        [DisplayName("Rozmiar ramki")]
        public string FrameSize { get; set; }
        [DisplayName("Kolor ramki")]
        public string FrameColor { get; set; }
        [Required]
        [Url]
        [DisplayName("Link URL do zdjęcia")]
        public string ImageUrl { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
