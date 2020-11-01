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

        public Polygon(double[][] vertices)
        {
            var vertexStrings = vertices.Select(v => $"[{v[0]}, {v[1]}]");
            RawVertices = $"[{string.Join(',', vertexStrings)}]";
        }

        [NotMapped]
        public ICollection<(double, double)> Vertices
        {
            get => JsonSerializer.Deserialize<double[][]>(RawVertices)
                .Select(x => (x[0], x[1]))
                .ToArray();
        }

        [Required]
        public string RawVertices { get; set; }
    }
}
