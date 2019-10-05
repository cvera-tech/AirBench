using System.Data.Entity;
using AirBench.Models;
using System.Threading.Tasks;

namespace AirBench.Data
{
    public interface IBenchContext
    {
        DbSet<Bench> Benches { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}