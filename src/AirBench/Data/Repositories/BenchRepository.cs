using AirBench.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace AirBench.Data.Repositories
{
    public class BenchRepository : IBenchRepository
    {
        private BenchContext _context;

        public BenchRepository(BenchContext context)
        {
            _context = context;
        }

        public bool Add(Bench entity)
        {
            try
            {
                _context.Benches.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                // TODO
                return false;
            }
        }

        public Bench Get(int id)
        {
            var bench = _context.Benches
                .Include(b => b.Reviews)
                .Single(b => b.Id == id);
            return bench;
        }

        public List<Bench> List()
        {
            return _context.Benches.ToList();
        }
    }
}