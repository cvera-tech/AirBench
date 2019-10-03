using System.Collections.Generic;

namespace AirBench.Api.Models
{
    public class ReviewListForResponse
    {
        public int BenchId { get; set; }

        public List<IReviewInfo> Reviews { get; set; }

        public ReviewListForResponse()
        {
            Reviews = new List<IReviewInfo>();
        }
    }
}