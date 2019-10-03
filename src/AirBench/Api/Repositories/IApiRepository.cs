using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirBench.Api.Repositories
{
    public interface IApiRepository<TEntityType>
    {
        Task<int?> AddAsync(TEntityType entity);
        Task<TEntityType> GetAsync(int id);
        Task<List<TEntityType>> ListAsync();
    }
}
