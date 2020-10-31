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
                Polygon = new Polygon()
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
