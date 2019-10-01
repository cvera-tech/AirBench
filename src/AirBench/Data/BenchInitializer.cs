using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirBench.Data
{
    public class BenchInitializer : DropCreateDatabaseAlways<BenchContext>
    {
        protected override void Seed(BenchContext context)
        {
            context.Benches.Add(new Bench() { Id = 1, Description = "Bench", Latitude = 10f, Longitude = 20f, NumberSeats = 4 });
            base.Seed(context);
        }
    }
}