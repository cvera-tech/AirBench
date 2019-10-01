using System.Collections.Generic;

namespace AirBench.Data.Repositories
{
    public interface IRepository<TEntityType>
    {
        TEntityType Get(int id);
        List<TEntityType> List();
    }
}