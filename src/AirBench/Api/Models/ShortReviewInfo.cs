using System;

namespace AirBench.Api.Models
{
    public class ShortReviewInfo : IReviewInfo
    {
        public string Description { get; set; }

        public int Rating { get; set; }

        public string Reviewer { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}