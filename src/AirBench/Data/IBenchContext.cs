using System.Data.Entity;
using AirBench.Models;

namespace AirBench.Data
{
    public interface IBenchContext
    {
        DbSet<Bench> Benches { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<User> Users { get; set; }

        void SaveChanges();
    }
}