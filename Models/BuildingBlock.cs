using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartCityPlanner.Models
{
    public class BuildingBlock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Polygon Polygon { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public ICollection<Polygon> GreenSpaces { get; set; }

        public ICollection<Polygon> ParkingLots { get; set; }
    }
}
