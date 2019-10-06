using AirBench.Models;
using System.Data.Entity;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // I don't like this
            modelBuilder.Entity<Review>()
                .HasRequired<User>(r => r.User)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}