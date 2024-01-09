using Microsoft.EntityFrameworkCore;

namespace LegoShop.Data
{
    public static class DbExtension
    {
        public static async Task MigrateDatabaseAsync(this IServiceCollection service)
        {
            using var scope = service.BuildServiceProvider()
                .CreateScope();

            var dbContext = scope.ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            var pendingMigrations = await dbContext.Database
                .GetPendingMigrationsAsync();

            if(pendingMigrations.Any())
                await dbContext.Database.MigrateAsync();
        }
    }
}
