using AirBench.Api.Models;
using AirBench.Api.Repositories;
using System.Threading.Tasks;
using System.Web.Http;

namespace AirBench.Api.Controllers
{
    public class ReviewController : ApiController
    {
        private IReviewApiRepository _repo;

        public ReviewController(IReviewApiRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ReviewListResponse> List()
        {
            var reviews = await _repo.ListAsync();
            var response = new ReviewListResponse();
            reviews.ForEach(r =>
            {
                var reviewInfo = new ReviewInfo()
                {
                    BenchId = r.BenchId,
                    Description = r.Description,
                    Rating = r.Rating
                };
                response.Reviews.Add(reviewInfo);
            });
            return response;
        }

        [HttpGet]
        public async Task<ReviewListForResponse> ListFor(int id)
        {
            var reviews = await _repo.ListForAsync(id);
            var response = new ReviewListForResponse()
            {
                BenchId = id
            };
            reviews.ForEach(r =>
            {
                var reviewInfo = new ShortReviewInfo()
                {
                    Description = r.Description,
                    Rating = r.Rating
                };
                response.Reviews.Add(reviewInfo);
            });

            return response;
        }
    }
}