using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartCityPlanner.Models
{
    public abstract class HeatMapData
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lng")]
        public double Longitude { get; set; }

        [Required]
        [JsonPropertyName("count")]
        public double Count { get; set; }
    }
}
