using System;

namespace AirBench.Api.Models
{
    public class ReviewInfo : IReviewInfo
    {
        public int Id { get; set; }

        public int BenchId { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string Reviewer { get; set; }
        
        public DateTimeOffset Date { get; set; }
    }
}