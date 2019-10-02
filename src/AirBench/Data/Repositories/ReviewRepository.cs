using System;
using System.Collections.Generic;
using AirBench.Models;
using System.Linq;

namespace AirBench.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private BenchContext _context;

        public ReviewRepository(BenchContext context)
        {
            _context = context;
        }

        public bool Add(Review entity)
        {
            try
            {
                _context.Reviews.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Review Get(int id)
        {
            using (var context = new BenchContext())
            {
                var review = context.Reviews
                    .Single(r => r.Id == id);
                return review;
            }
        }

        public List<Review> List()
        {
            using (var context = new BenchContext())
            {
                var reviews = context.Reviews.ToList();
                return reviews;
            }
        }
    }
}