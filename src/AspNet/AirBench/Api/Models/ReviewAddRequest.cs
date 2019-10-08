namespace AirBench.Api.Models
{
    public class ReviewAddRequest
    {
        public string Description { get; set; }

        public int Rating { get; set; }

        public int UserId { get; set; }
    }
}