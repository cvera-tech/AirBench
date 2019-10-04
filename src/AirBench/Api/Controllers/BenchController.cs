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

        /// <summary>
        /// Attempts to add a bench.
        /// 
        /// ROUTE:
        /// "bench/add"
        /// 
        /// REQUEST BODY:
        /// {
        ///     "Description": `string`,
        ///     "Latitude": `float`,
        ///     "Longitude": `float`,
        ///     "NumberSeats": `int`
        /// }
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "Success": `bool`,
        ///     "Id": `int`,
        ///     "Description": `string`,
        ///     "Latitude": `float`,
        ///     "Longitude": `float`,
        ///     "NumberSeats": `int`
        /// }
        /// </summary>
        /// <param name="request">The request body.</param>
        /// <returns>The response body.</returns>
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

        /// <summary>
        /// Attempts to retrieve the bench with the given ID.
        /// 
        /// ROUTE:
        /// "bench/details/{id}"
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "Success": `bool`,
        ///     "Id": `int`,
        ///     "Description": `string`,
        ///     "Latitude": `float`,
        ///     "Longitude": `float`,
        ///     "NumberSeats": `int`,
        ///     "AverageRating": `double`
        ///     "Reviews": [
        ///         {
        ///             "description": `string`,
        ///             "rating": `int`,
        ///             "reviewer": `string`
        ///             "date": `datetimeoffset`
        ///         }
        ///         .
        ///         .
        ///         .
        ///     ]
        /// }
        /// </summary>
        /// <param name="id">The bench ID.</param>
        /// <returns>The response body.</returns>
        [HttpGet]
        public async Task<BenchDetailsResponse> Details(int id)
        {
            var bench = await _benchRepo.GetAsync(id);
            var response = new BenchDetailsResponse();
            if (bench != null)
            {
                response.Success = true;
                response.Id = bench.Id;
                response.Description = bench.Description;
                response.Latitude = bench.Latitude;
                response.Longitude = bench.Longitude;
                response.NumberSeats = bench.NumberSeats;
                response.AverageRating = bench.AverageRating;
                response.AddedBy = bench.User.ShortName;

                bench.Reviews.ForEach(r =>
                {
                    var reviewInfo = new ShortReviewInfo();
                    reviewInfo.Description = r.Description;
                    reviewInfo.Rating = r.Rating;
                    reviewInfo.Reviewer = r.User.ShortName;
                    reviewInfo.Date = r.Date;
                    response.Reviews.Add(reviewInfo);
                });
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        /// <summary>
        /// Retrieves the list of all benches.
        /// 
        /// ROUTE:
        /// "bench/list"
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "Benches": [
        ///         {
        ///             "Id": `int`,
        ///             "Description": `string',
        ///             "Latitude": `float`,
        ///             "Longitude": `float`,
        ///             "NumberSeats": `int`,
        ///             "AverageRating": `double`
        ///         }
        ///         .
        ///         .
        ///         .
        ///     ]
        /// }
        /// </summary>
        /// <returns>The response body.</returns>
        [HttpGet]
        public async Task<BenchListResponse> List()
        {
            var benches = await _benchRepo.ListAsync();
            var response = new BenchListResponse();
            benches.ForEach(b =>
            {
                var benchInfo = new ShortBenchInfo()
                {
                    Id = b.Id,
                    Description = b.Description,
                    Latitude = b.Latitude,
                    Longitude = b.Longitude,
                    NumberSeats = b.NumberSeats,
                    AverageRating = b.AverageRating,
                    AddedBy = b.User.ShortName
                };
                response.Benches.Add(benchInfo);
            });
            return response;
        }

    }
}