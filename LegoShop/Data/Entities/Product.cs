namespace LegoShop.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MosaicType { get; set; }
        public string FrameSize { get; set; }
        public string FrameColor { get; set; }
        public string ImageUrl { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
