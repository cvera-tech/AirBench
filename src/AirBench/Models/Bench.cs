using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class Bench
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public int NumberSeats { get; set; }

        // Navigation property
        public List<Review> Reviews { get; set; }

        public override string ToString()
        {
            return $"[{Id}] ({Latitude}, {Longitude}) {Description}";
        }
    }
}