using AirBench.Models;
using System.Data.Entity;

namespace AirBench.Data
{
    public class BenchInitializer : DropCreateDatabaseAlways<BenchContext>
    {
        protected override void Seed(BenchContext context)
        {
            context.Benches.Add(new Bench() { Id = 1, Description = "Bench", Latitude = 10f, Longitude = 20f, NumberSeats = 4 });
        }
    }
}