using System;
using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTimeOffset Date { get; set; }

        // Foreign keys
        public int BenchId { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public Bench Bench { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return $"[{Id}] (Bench {BenchId}) {Rating}: {Description}";
        }
    }
}