using AirBench.Api.Models;
using AirBench.Api.Repositories;
using AirBench.Models;
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

        [HttpPost]
        public async Task<BenchAddResponse> Add(BenchAddRequest request)
        {
            var bench = new Bench()
            {
                Description = request.Description,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                NumberSeats = request.NumberSeats
            };
            var benchId = await _benchRepo.AddAsync(bench);
            var response = new BenchAddResponse();
            if (benchId.HasValue) 
            {
                response.Success = true;
                response.Id = benchId.Value;
                response.Description = bench.Description;
                response.Latitude = bench.Latitude;
                response.Longitude = bench.Longitude;
                response.NumberSeats = bench.NumberSeats;
            }
            else
            {
                response.Success = false;
            }
            return response;
        }

        [HttpGet]
        public async Task<BenchDetailsResponse> Details(int id)
        {
            var bench = await _benchRepo.GetAsync(id);
            var response = new BenchDetailsResponse() {
                Id = bench.Id,
                Description = bench.Description,
                Latitude = bench.Latitude,
                Longitude = bench.Longitude,
                NumberSeats = bench.NumberSeats,
                AverageRating = bench.AverageRating
            };
            bench.Reviews.ForEach(r =>
            {
                var reviewInfo = new ReviewInfo()
                {
                    Description = r.Description,
                    Rating = r.Rating
                };
                response.Reviews.Add(reviewInfo);
            });

            return response;
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