using LegoShop.Data.Seeders.Seeds;
using LegoShop.Data.Seeders.SeedService;

namespace LegoShop.Data.Seeders
{
    public static class SeedExtension
    {
        public static async Task ExecuteSeeds(this IServiceCollection serviceCollection)
        {
            using var scope = serviceCollection.BuildServiceProvider().CreateScope();

            var seeder = scope.ServiceProvider
                .GetRequiredService<ISeedService>();

            await seeder.ExecuteSeeds();
        }
    }
}
