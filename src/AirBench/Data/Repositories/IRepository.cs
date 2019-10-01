using System.Collections.Generic;

namespace AirBench.Data.Repositories
{
    public interface IRepository<TEntityType>
    {
        bool Add(TEntityType entity);
        TEntityType Get(int id);
        List<TEntityType> List();
    }
}