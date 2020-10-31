using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SmartCityPlanner.Models
{
    [Owned]
    public class Polygon
    {
        public Polygon()
        {
            RawVertices = "[]";
        }

        public Polygon(string vertices)
        {
            RawVertices = vertices;
        }

        [NotMapped]
        public List<(double, double)> Vertices
        {
            get => JsonSerializer.Deserialize<List<List<double>>>(RawVertices)
                .Select(x => (x[0], x[1]))
                .ToList();
        }

        [Required]
        public string RawVertices { get; set; }
    }
}
