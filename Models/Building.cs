using System.ComponentModel.DataAnnotations;

namespace SmartCityPlanner.Models
{
    public class Building
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public BuildingType BuildingType { get; set; }

        [Required]
        public Polygon Vertices { get; set; }

        public string ModelUrn { get; set; }

        public string Owner { get; set; }

        [Range(1, 4)]
        public ushort SeismicRisk { get; set; }

        public uint PeopleCount { get; set; }

        public double ComputeArea()
        {
            // TODO(Condrat): implement
            return 0;
        }
    }

    public enum BuildingType
    {
        Residential,
        Economic,
        Entertainment,
        Administrative,
        Educational,
    }
}
