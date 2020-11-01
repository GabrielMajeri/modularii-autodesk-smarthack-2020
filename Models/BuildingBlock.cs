using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartCityPlanner.Models
{
    public class BuildingBlock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Polygon Polygon { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public ICollection<GreenSpace> GreenSpaces { get; set; }

        public ICollection<ParkingLot> ParkingLots { get; set; }
    }
}
