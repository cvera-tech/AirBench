﻿namespace AirBench.Api.Models
{
    public class BenchAddResponse
    {
        public bool Success { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }
        
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public float NumberSeats { get; set; }
    }
}