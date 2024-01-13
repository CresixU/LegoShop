using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LegoShop.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [DisplayName("Nazwa produktu")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MosaicType { get; set; }
        public string FrameSize { get; set; }
        public string FrameColor { get; set; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
