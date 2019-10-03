using AirBench.Models;
using System.Data.Entity;
using System;

namespace AirBench.Data
{
    public class BenchContext : DbContext, IBenchContext
    {
        public DbSet<Bench> Benches { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public BenchContext() : base("bestBenches")
        {
            Database.SetInitializer(new BenchInitializer());
        }

        void IBenchContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}