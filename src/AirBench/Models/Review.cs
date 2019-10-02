using System.ComponentModel.DataAnnotations;

namespace AirBench.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        // Foreign Key
        public int BenchId { get; set; }
        public Bench Bench { get; set; }

        public override string ToString()
        {
            return $"[{Id}] (Bench {BenchId}) {Rating}: {Description}";
        }
    }
}