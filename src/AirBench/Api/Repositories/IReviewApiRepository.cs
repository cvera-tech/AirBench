using AirBench.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirBench.Api.Repositories
{
    public interface IReviewApiRepository : IApiRepository<Review>
    {
        Task<List<Review>> ListForAsync(int id);
    }
}
