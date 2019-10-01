using AirBench.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace AirBench.Data
{
    public class BenchInitializer : DropCreateDatabaseAlways<BenchContext>
    {
        protected override void Seed(BenchContext context)
        {
            var benches = new List<Bench>();
            benches.Add(new Bench() { Description = "Bench", Latitude = 10f, Longitude = 20f, NumberSeats = 4 });
            benches.Add(new Bench() { Description = "Uncomfortable Bench", Latitude = 13f, Longitude = 27f, NumberSeats = 2 });
            benches.Add(new Bench() { Description = "Weird Bench", Latitude = 5f, Longitude = 2f, NumberSeats = 7 });
            benches.Add(new Bench() { Description = "Actually a chair", Latitude = -3f, Longitude = 26f, NumberSeats = 1 });

            benches.ForEach(b => context.Benches.Add(b));
            base.Seed(context);
        }
    }
}