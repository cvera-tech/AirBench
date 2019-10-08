using System.ComponentModel.DataAnnotations;

namespace AirBench.Api.Models
{
    public class BenchAddRequest
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public float? Latitude { get; set; }

        [Required]
        public float? Longitude { get; set; }

        [Required]
        public int? NumberSeats { get; set; }

        [Required]
        public int? UserId { get; set; }
    }
}