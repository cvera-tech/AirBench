using System;

namespace AirBench.Api.Models
{
    public interface IReviewInfo
    {
        string Description { get; set; }

        int Rating { get; set; }
        
        string Reviewer { get; set; }

        DateTimeOffset Date { get; set; }
    }
}
