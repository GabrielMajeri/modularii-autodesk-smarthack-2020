using System.ComponentModel.DataAnnotations;

namespace SmartCityPlanner.Models
{
    public class DocumentGenerator
    {
        public string ArchitechtName { get; set; }
        public float BuildingArea { get; set; }

        public float BuildingPerimetre { get; set; }

        public DocumentGenerator(string _name, float _area, float _perimetre)
        {
            ArchitechtName = _name;
            BuildingArea = _area;
            BuildingPerimetre = _perimetre;
        }

    }
}
