using AirBench.Api.Models;
using AirBench.Api.Repositories;
using AirBench.Models;
using System;
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
        /// "review/{id}"
        /// 
        /// REQUEST BODY:
        /// {
        ///     "Description": `string`,
        ///     "Rating": `int`,
        ///     "UserId": `int`
        /// }
        /// 
        /// RESPONSE BODY:
        /// {
        ///     "Success": `bool`,
        ///     "Id": `int`,
        ///     "BenchId": `int`,
        ///     "Description": `string`,
        ///     "Rating": `int`
        ///     "UserId": `int`
        ///     "Date": `datetimeoffset
        /// }
        /// </summary>
        /// <param name="id">The bench ID.</param>
        /// <param name="request">The request body.</param>
        /// <returns>The response body.</returns>
        public async Task<ReviewAddResponse> Post(int id, ReviewAddRequest request)
        {
            var review = new Review()
            {
                BenchId = id,
                Description = request.Description,
                Rating = request.Rating,
                UserId = request.UserId,
                Date = DateTimeOffset.Now
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
                response.Date = review.Date;
                response.UserId = review.UserId;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }
    }
}