using AirBench.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace AirBench.Data
{
    public class BenchInitializer : DropCreateDatabaseAlways<BenchContext>
    {
        protected override void Seed(BenchContext context)
        {
            var users = new List<User>();
            users.Add(new User() {
                Username = "john@email.com",
                HashedPassword = "$2a$10$N1ZGSPeT0Kt1QtKAphb5XOB73L110Wf8R26SCktIZNbZe7VqrNiyy",
                FirstName = "John",
                LastName = "Vera"
            });
            users.Add(new User()
            {
                Username ="moira@email.com",
                HashedPassword = "$2a$10$qch4fvbAj7I.5FCv9DckouymvNGvot.zQrsHGqGVoo5ULkgkinRSq",
                FirstName = "Moira",
                LastName = "Brown"
            });
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var benches = new List<Bench>();
            benches.Add(new Bench() { Description = "Bench", Latitude = 10f, Longitude = 20f, NumberSeats = 4, UserId = 1 });
            benches.Add(new Bench() { Description = "Uncomfortable Bench", Latitude = 13f, Longitude = 27f, NumberSeats = 2, UserId = 1 });
            benches.Add(new Bench() { Description = "Weird Bench", Latitude = 5f, Longitude = 2f, NumberSeats = 7, UserId = 1 });
            benches.Add(new Bench() { Description = "Actually a chair", Latitude = -3f, Longitude = 26f, NumberSeats = 1, UserId = 1 });
            benches.Add(new Bench() { Description = "This bench has a really long description because SOME people think that long descriptions need to be supported", Latitude = 2f, Longitude = 2f, NumberSeats = 10, UserId = 2 });
            benches.ForEach(b => context.Benches.Add(b));

            var reviews = new List<Review>();
            reviews.Add(new Review() { BenchId = 1, Description = "Decent", Rating = 3 });
            reviews.Add(new Review() { BenchId = 1, Description = "Pretty nice", Rating = 4 });
            reviews.Add(new Review() { BenchId = 1, Description = "Worst. Bench. Ever.", Rating = 1 });
            reviews.Add(new Review() { BenchId = 2, Description = "Spiky", Rating = 1 });
            reviews.Add(new Review() { BenchId = 2, Description = "Poorly maintained", Rating = 2 });
            reviews.ForEach(r => context.Reviews.Add(r));

            context.SaveChanges();
        }
    }
}