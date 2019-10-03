using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirBench.Api.Repositories
{
    /// <summary>
    /// This class defines a generic set of methods common to all API repositories.
    /// </summary>
    /// <typeparam name="TEntityType">The entity type the implementing repository handles.</typeparam>
    public interface IApiRepository<TEntityType>
    {
        /// <summary>
        /// Attempts to add an entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity's ID in the database if successful; null otherwise.</returns>
        Task<int?> AddAsync(TEntityType entity);

        /// <summary>
        /// Attempts to retrieve an entity from the database given its ID.
        /// </summary>
        /// <param name="id">The entity's ID in the database.</param>
        /// <returns>The entity record if successfull; null otherwise.</returns>
        Task<TEntityType> GetAsync(int id);

        /// <summary>
        /// Retrieves the list of records of the entity type from the database.
        /// </summary>
        /// <returns>The list of entities.</returns>
        Task<List<TEntityType>> ListAsync();
    }
}
