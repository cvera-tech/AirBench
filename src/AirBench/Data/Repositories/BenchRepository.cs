using AirBench.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AirBench.Data.Repositories
{
    public class BenchRepository : IBenchRepository
    {
        public Bench Get(int id)
        {
            using (var context = new BenchContext())
            {
                var bench = context.Benches
                    .Single(b => b.Id == id);
                return bench;
            }
        }

        public List<Bench> List()
        {
            using (var context = new BenchContext())
            {
                return context.Benches.ToList();
            }
        }
    }
}