using System.Collections.Generic;
using LegoShop.Data.Seeders.Seeds;

namespace LegoShop.Data.Seeders.SeedService
{
    public sealed class SeedService : ISeedService
    {
        private readonly IEnumerable<IEntitySeeder> _seeds;
        public SeedService(IEnumerable<IEntitySeeder> seeds)
        {
            _seeds = seeds;

        }
        public async Task<bool> ExecuteSeeds()
        {
            foreach (var seed in _seeds)
            {
                await seed.Seed();
            }
            return true;
        }
    }
}
