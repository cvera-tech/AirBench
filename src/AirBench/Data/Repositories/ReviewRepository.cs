using System.Collections.Generic;
using AirBench.Models;
using System.Linq;

namespace AirBench.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private IBenchContext _context;

        public ReviewRepository(IBenchContext context)
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
            var review = _context.Reviews
                .SingleOrDefault(r => r.Id == id);
            return review;
        }

        public List<Review> List()
        {
            var reviews = _context.Reviews
                .ToList();
            return reviews;
        }

        public List<Review> ListSimple()
        {
            return _context.Reviews
                .ToList();
        }
    }
}