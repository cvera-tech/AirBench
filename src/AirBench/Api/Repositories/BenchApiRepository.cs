using AirBench.Data;
using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AirBench.Api.Repositories
{
    public class BenchApiRepository : IBenchApiRepository
    {
        private IBenchContext _context;

        public BenchApiRepository(IBenchContext context)
        {
            _context = context;
        }

        public async Task<int?> AddAsync(Bench entity)
        {
            try
            {
                _context.Benches.Add(entity);
                await _context.SaveChangesAsync();
                var result = entity.Id;
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Bench> GetAsync(int id)
        {
            // Two queries to take advantage of EF relationship fix-up
            var benches = await _context.Benches
                .Include(b => b.User)
                .SingleOrDefaultAsync(b => b.Id == id);

            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Where(r => r.BenchId == id)
                .OrderByDescending(r => r.Date)
                .ToListAsync();

            return benches;
        }

        public async Task<List<Bench>> ListAsync()
        {
            return await _context.Benches
                .Include(b => b.Reviews)
                .Include(b => b.User)
                .ToListAsync();
        }
    }
}