using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SmartCityPlanner.Models;

namespace SmartCityPlanner.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<BuildingBlock> BuildingBlocks { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<TemperatureData> TemperatureData { get; set; }
        public DbSet<TemperatureData> RainfallData { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        public void Seed()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            SaveChanges();

            var buildingBlocksJson = File.ReadAllText("SeedData/BuildingBlocks.json");
            var buildingBlocks = JsonSerializer.Deserialize<JsonBuildingBlock[]>(buildingBlocksJson);

            foreach (var block in buildingBlocks)
            {
                Add(new BuildingBlock
                {
                    Id = block.Id,
                    Polygon = new Polygon(block.Vertices)
                });
            }

            LoadHeatMapData<TemperatureData>("SeedData/Temperatures.json");

            SaveChanges();
        }

        private void LoadHeatMapData<T>(string path) where T : HeatMapData
        {
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<T[]>(json);
            foreach (var item in data)
            {
                Add(item);
            }
        }

        private class JsonBuildingBlock
        {
            public int Id { get; set; }
            public double[][] Vertices { get; set; }
        }
    }
}
