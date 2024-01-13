using LegoShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LegoShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public async Task<int> ExecuteRawSqlAsync(string sqlQuery)
            => await Database.ExecuteSqlRawAsync(sqlQuery);

        public async Task BeginTranstaction()
            => await Database.BeginTransactionAsync();

        public async Task CommitTransaction()
            => await Database.CommitTransactionAsync();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                b.OwnsOne(x => x.Address);

                b.Navigation(u => u.Address)
                    .IsRequired();
            });


            builder.Entity<Order>(b =>
            {
                b.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId);

                b.HasOne(o => o.OrderStatus)
                    .WithMany(os => os.Orders)
                    .HasForeignKey(o => o.OrderStatusId);

                b.HasOne(o => o.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.ProductId);

                b.Property(o => o.TotalPrice)
                    .HasColumnType("decimal")
                    .HasDefaultValue(0);
            });


            builder.Entity<Product>(b =>
            {
                b.Property(p => p.Price)
                    .HasColumnType("decimal")
                    .HasDefaultValue(0);

                b.HasOne(p => p.User)
                    .WithMany(u => u.Products)
                    .HasForeignKey(p => p.UserId);
            });

        }
    }
}