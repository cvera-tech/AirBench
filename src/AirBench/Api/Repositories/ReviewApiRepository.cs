using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using AirBench.Models;
using AirBench.Data;

namespace AirBench.Api.Repositories
{
    public class ReviewApiRepository : IReviewApiRepository
    {
        private IBenchContext _context;

        public ReviewApiRepository(IBenchContext context)
        {
            _context = context;
        }

        public async Task<int?> AddAsync(Review entity)
        {
            try
            {
                _context.Reviews.Add(entity);
                await _context.SaveChangesAsync();
                var id = entity.Id;
                return id;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Review> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Review>> ListAsync()
        {
            var reviews = await _context.Reviews
                .ToListAsync();
            return reviews;
        }

        public async Task<List<Review>> ListForAsync(int id)
        {
            var reviews = await _context.Reviews
                .Where(r => r.BenchId == id)
                .ToListAsync();
            return reviews;
        }
    }
}