using AirBench.Api.Models;
using AirBench.Api.Repositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace AirBench.Api.Controllers
{
    public class BenchController : ApiController
    {
        private IBenchApiRepository _benchRepo;

        public BenchController(IBenchApiRepository benchRepo)
        {
            _benchRepo = benchRepo;
        }
        
        [HttpGet]
        public async Task<BenchListResponse> List()
        {
            var benches = await _benchRepo.ListAsync();
            var response = new BenchListResponse();
            benches.ForEach(b =>
            {
                var benchInfo = new ShortBenchInfo() {
                    Id = b.Id,
                    Description = b.Description,
                    Latitude = b.Latitude,
                    Longitude = b.Longitude,
                    NumberSeats = b.NumberSeats,
                    AverageRating = b.AverageRating
                };
                response.Benches.Add(benchInfo);
            });
            return response;
        }
    }
}