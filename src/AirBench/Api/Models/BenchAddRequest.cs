namespace AirBench.Api.Models
{
    public class BenchAddRequest
    {
        public string Description { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public int NumberSeats { get; set; }
    }
}