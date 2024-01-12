using LegoShop.Data.Entities;

namespace LegoShop.Data.Seeders.Seeds
{
    public class OrderStatusesSeeder : IEntitySeeder
    {
        private readonly ApplicationDbContext _context;

        public OrderStatusesSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync() && !_context.OrderStatuses.Any())
            {
                var data = new List<OrderStatus>()
                {
                    new OrderStatus() { ConstId = 1, Name = "New", IsImmutable = true },
                    new OrderStatus() { ConstId = 2, Name = "Payment recived"},
                    new OrderStatus() { ConstId = 3, Name = "Payment failed"},
                    new OrderStatus() { ConstId = 4, Name = "In progress", IsImmutable = true },
                    new OrderStatus() { ConstId = 5, Name = "Completed", IsImmutable = true},
                    new OrderStatus() { ConstId = 6, Name = "Closed", IsImmutable = true},
                    new OrderStatus() { ConstId = 7, Name = "Canceled", IsImmutable = true}
                };

                await _context.AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
