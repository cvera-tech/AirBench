using AirBench.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirBench.Api.Repositories
{
    public interface IReviewApiRepository : IApiRepository<Review>
    {
        /// <summary>
        /// Returns a list of reviews for a bench with the given ID.
        /// This method does not check for the existence of the bench.
        /// </summary>
        /// <param name="id">ID of the bench.</param>
        /// <returns>List of reviews for the bench.</returns>
        Task<List<Review>> ListForAsync(int id);
    }
}
