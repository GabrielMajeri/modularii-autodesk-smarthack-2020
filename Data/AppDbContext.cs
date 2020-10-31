using Microsoft.EntityFrameworkCore;
using SmartCityPlanner.Models;

namespace SmartCityPlanner.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<BuildingBlock> BuildingBlocks { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        public void Seed()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            SaveChanges();

            Add(new BuildingBlock
            {
                Id = 1,
                Polygon = new Polygon(@"[
        [44.43059042103043, 26.103947320513782],
        [44.43000240173962, 26.103987553646327],
        [44.43001006326678, 26.104309418707007],
        [44.430071355447986, 26.104306736498156],
        [44.430069440068294, 26.1043362407954],
        [44.429990909446985, 26.10435233404841],
        [44.430136478320094, 26.104937055575284],
        [44.4304793298913, 26.104464986819643],
        [44.43048124525754, 26.104298689871673],
        [44.43058275957935, 26.104285278827476],
        [44.43058084421642, 26.10407606653802],
        [44.430586590305005, 26.103939273887256]
    ]")
            });
            Add(new BuildingBlock
            {
                Id = 2,
                Polygon = new Polygon()
            });

            SaveChanges();
        }
    }
}
