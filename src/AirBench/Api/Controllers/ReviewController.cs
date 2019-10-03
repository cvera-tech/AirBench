using AirBench.Api.Models;
using AirBench.Api.Repositories;
using AirBench.Models;
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

        /// <summary>
        /// Attempts to add a review to the bench with the given ID.
        /// 
        /// ROUTE:
        /// "review/add/{id}"
        /// 
        /// REQUEST BODY:
        /// {
        ///     "Description": `string`,
        ///     "Rating": `int`
        /// }
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "Success": `bool`,
        ///     "Id": `int`,
        ///     "BenchId": `int`,
        ///     "Description": `string`,
        ///     "Rating": `int`
        /// }
        /// </summary>
        /// <param name="id">The bench ID.</param>
        /// <param name="request">The request body.</param>
        /// <returns>The response body.</returns>
        [HttpPost]
        public async Task<ReviewAddResponse> Add(int id, ReviewAddRequest request)
        {
            var review = new Review()
            {
                BenchId = id,
                Description = request.Description,
                Rating = request.Rating
            };

            var reviewId = await _repo.AddAsync(review);
            var response = new ReviewAddResponse();
            if (reviewId.HasValue)
            {
                response.Success = true;
                response.Id = reviewId.Value;
                response.BenchId = id;
                response.Description = review.Description;
                response.Rating = review.Rating;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        /// <summary>
        /// Attempts to retrieve the review with the given ID.
        /// 
        /// ROUTE:
        /// "review/details/{id}"
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "Success": `bool`,
        ///     "Id": `int`,
        ///     "BenchId": `int`,
        ///     "Description": `string`,
        ///     "Rating": `int`
        /// }
        /// </summary>
        /// <param name="id">The review ID.</param>
        /// <returns>The response body.</returns>
        [HttpGet]
        public async Task<ReviewDetailsResponse> Details(int id)
        {
            var review = await _repo.GetAsync(id);
            var response = new ReviewDetailsResponse();
            if (review != null)
            {
                response.Success = true;
                response.Id = review.Id;
                response.BenchId = review.BenchId;
                response.Description = review.Description;
                response.Rating = review.Rating;
            }
            else
            {
                response.Success = false;
            };
            return response;
        }

        /// <summary>
        /// Retrieves the list of all reviews.
        /// 
        /// ROUTE:
        /// "review/list"
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "Reviews": [
        ///         {
        ///             "BenchId": `int`,
        ///             "Description": `string`,
        ///             "Rating": `int`
        ///         },
        ///             .
        ///             .
        ///             .
        ///     ]
        /// }
        /// </summary>
        /// <param name="id">The review ID.</param>
        /// <returns>The response body.</returns>
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

        /// <summary>
        /// Attempts to retrieve the list of all reviews for the bench with the given ID.
        /// 
        /// ROUTE:
        /// "review/listfor/{id}"
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "BenchId": {
        ///     "Reviews": [
        ///         {
        ///             "BenchId": `int`,
        ///             "Description": `string`,
        ///             "Rating": `int`
        ///         },
        ///             .
        ///             .
        ///             .
        ///     ]
        /// }
        /// </summary>
        /// <param name="id">The bench ID.</param>
        /// <returns>The response body.</returns>
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