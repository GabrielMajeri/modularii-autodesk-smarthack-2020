using System.Collections.Generic;
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
        public DbSet<GreenSpace> GreenSpaces { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }


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
                    Name = block.Name,
                    Polygon = new Polygon(block.Vertices),
                    Buildings = new List<Building>
                    {
                        new Building
                        {
                            Id = block.Id,
                            Vertices = new Rectangle
                            {
                                X = 50,
                                Y = 20,
                                Width = 300,
                            },
                            Owner = "Mihai Condrat",
                            BuildingType = BuildingType.Residential,
                            ModelUrn = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6c29xbmJqaGFvN2h2bWZsc2F2Y2dpcWxvdmxyOHhjazZfdHV0b3JpYWxfYnVja2V0L3JzdF9iYXNpY19zYW1wbGVfcHJvamVjdC5ydnQ="
                        },
                        new Building
                        {
                            Id = 1000 + block.Id,
                            Vertices = new Rectangle
                            {
                                X = 20,
                                Y = 400,
                                Height = 150,
                                Width = 200,
                            },
                            Owner = "Ionuț Costea",
                            BuildingType = BuildingType.Economic,
                            ModelUrn = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6c29xbmJqaGFvN2h2bWZsc2F2Y2dpcWxvdmxyOHhjazZfdHV0b3JpYWxfYnVja2V0L3JzdF9iYXNpY19zYW1wbGVfcHJvamVjdC5ydnQ="
                        },
                        new Building
                        {
                            Id = 2000 + block.Id,
                            Vertices = new Rectangle
                            {
                                X = 400,
                                Y = 100,
                                Width = 100,
                                Height = 200,
                                Rotation = -45
                            },
                            Owner = "Anonimus",
                            BuildingType = BuildingType.Entertainment,
                            ModelUrn = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6c29xbmJqaGFvN2h2bWZsc2F2Y2dpcWxvdmxyOHhjazZfdHV0b3JpYWxfYnVja2V0L3JzdF9iYXNpY19zYW1wbGVfcHJvamVjdC5ydnQ="
                        }
                    },
                    GreenSpaces = new List<GreenSpace>
                    {
                        new GreenSpace
                        {
                            Id = block.Id,
                            Vertices = new Rectangle
                            {
                                X = 20,
                                Y = 300,
                                Width = 400,
                                Rotation = 5
                            }
                        }
                    },
                    ParkingLots = new List<ParkingLot>()
                });
            }

            LoadHeatMapData<TemperatureData>("SeedData/Temperatures.json");

            SaveChanges();
        }

        private class JsonBuildingBlock
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double[][] Vertices { get; set; }
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
    }
}
