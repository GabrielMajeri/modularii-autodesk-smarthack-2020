using System.ComponentModel.DataAnnotations;

namespace SmartCityPlanner.Models
{
    public abstract class EditableEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Rectangle Vertices { get; set; }

        public double ComputeArea()
        {
            // TODO(Condrat): implement
            return 0;
        }

        public double ComputePerimeter()
        {
            // TODO(Condrat): implement
            return 0;
        }
    }
}
