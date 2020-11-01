using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SmartCityPlanner
{
    [Owned]
    public class Rectangle
    {
        [Required]
        public double X { get; set; } = 0;
        [Required]
        public double Y { get; set; } = 0;

        [Required]
        public double Width { get; set; } = 100;
        [Required]
        public double Height { get; set; } = 100;

        [Required]
        public double ScaleX { get; set; } = 1;
        [Required]
        public double ScaleY { get; set; } = 1;

        [Required]
        public double Rotation { get; set; } = 0;
    }
}
