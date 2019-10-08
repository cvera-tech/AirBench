using System.Collections.Generic;

namespace AirBench.Api.Models
{
    public class BenchListResponse
    {
        public List<ShortBenchInfo> Benches { get; set; }
        
        public BenchListResponse()
        {
            Benches = new List<ShortBenchInfo>();
        }
    }
}