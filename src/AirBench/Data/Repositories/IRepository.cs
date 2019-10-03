using System.Collections.Generic;

namespace AirBench.Data.Repositories
{
    public interface IRepository<TEntityType>
    {
        bool Add(TEntityType entity);
        TEntityType Get(int id);
        List<TEntityType> List();

        /// <summary>
        /// Returns a list of entities without any instantiated navigation properties.
        /// </summary>
        /// <returns>The list of entities.</returns>
        List<TEntityType> ListSimple();
    }
}