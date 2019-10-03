using System.Collections.Generic;

namespace AirBench.Api.Models
{
    public class ReviewListResponse
    {
        public List<IReviewInfo> Reviews { get; set; }

        public ReviewListResponse()
        {
            Reviews = new List<IReviewInfo>();
        }
    }
}