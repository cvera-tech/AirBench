using System.Collections.Generic;

namespace AirBench.Api.Models
{
    public class BenchDetailsResponse
    {
        public bool Success { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public int NumberSeats { get; set; }

        public double? AverageRating { get; set; }

        public string AddedBy { get; set; }

        public List<IReviewInfo> Reviews { get; set; }

        public BenchDetailsResponse()
        {
            Reviews = new List<IReviewInfo>();
        }
    }
}