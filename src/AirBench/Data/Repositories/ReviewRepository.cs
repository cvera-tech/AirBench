using System;
using System.Collections.Generic;
using AirBench.Models;
using System.Linq;

namespace AirBench.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public bool Add(Review entity)
        {
            throw new NotImplementedException();
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