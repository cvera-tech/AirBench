using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        // Foreign key properties
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public List<Review> Reviews { get; set; }

        public double? AverageRating
        {
            get
            {
                if (Reviews.Count == 0)
                {
                    return null;
                }
                else
                {
                    var average = Reviews.Average(r => r.Rating);
                    return Math.Round(average, 1);
                }
            }
        }

        public Bench()
        {
            Reviews = new List<Review>();
        }

        public override string ToString()
        {
            return $"[{Id}] ({Latitude}, {Longitude}) {Description}";
        }
    }
}