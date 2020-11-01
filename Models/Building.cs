using System.ComponentModel.DataAnnotations;

namespace SmartCityPlanner.Models
{
    public class Building : EditableEntity
    {
        [Required]
        public BuildingType BuildingType { get; set; }

        public string ModelUrn { get; set; }

        public string Owner { get; set; }

        [Range(1, 4)]
        public ushort SeismicRisk { get; set; }

        public uint PeopleCount { get; set; }
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
