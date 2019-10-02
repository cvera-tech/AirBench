using AirBench.Data;
using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<bool> AddAsync(Bench entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Bench> GetAsync(int id)
        {
            return await _context.Benches
                .Include(b => b.Reviews)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Bench>> ListAsync()
        {
            return await _context.Benches
                .Include(b => b.Reviews)
                .ToListAsync();
        }
    }
}