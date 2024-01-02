using LegoShop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LegoShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public new DbSet<AppUser> Users { get; set; }
        public new DbSet<UserRole> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(b =>
            {
                b.OwnsOne(x => x.Address);

                b.Navigation(u => u.Address)
                    .IsRequired();
                

                b.HasOne(u => u.UserRole)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.UserRoleId);


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
                    .HasDefaultValue(0)
                    .HasPrecision(2);
            });

            builder.Entity<Product>(b =>
            {
                b.Property(p => p.Price)
                    .HasColumnType("decimal")
                    .HasDefaultValue(0)
                    .HasPrecision(2);
            });

        }
    }
}