using System.Web.Mvc;
using AirBench.Models.ViewModels;
using AirBench.Data.Repositories;
using AirBench.Models;
using AirBench.Security;
using System;

namespace AirBench.Controllers
{
    public class BenchController : Controller
    {
        private IBenchRepository benchRepo;
        private IReviewRepository reviewRepo;

        public BenchController(IBenchRepository benchRepo, IReviewRepository reviewRepo)
        {
            this.benchRepo = benchRepo;
            this.reviewRepo = reviewRepo;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(float lat, float lon)
        {
            var viewModel = new BenchAddViewModel()
            {
                Latitude = lat,
                Longitude = lon
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BenchAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bench = new Bench()
                {
                    Description = viewModel.Description,
                    Latitude = viewModel.Latitude.Value,
                    Longitude = viewModel.Longitude.Value,
                    NumberSeats = viewModel.NumberSeats,
                    UserId = ((CustomPrincipal)User).Id
                };
                // TODO validation
                if (benchRepo.Add(bench))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to add bench.");
                }
            }
            else
            {
                ModelState.AddModelError("", "All fields are required.");
            }
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var bench = benchRepo.Get(id);
            return View(bench);
        }

        public ActionResult Review(int id)
        {
            var bench = benchRepo.Get(id);
            var viewModel = new ReviewAddViewModel()
            {
                Bench = bench
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review(int id, ReviewAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var review = new Review()
                {
                    BenchId = id,
                    Description = viewModel.Description,
                    Rating = viewModel.Rating,
                    UserId = ((CustomPrincipal)User).Id,
                    Date = DateTimeOffset.Now
                };

                if (reviewRepo.Add(review))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to add review.");
                }
            }
            else
            {
                ModelState.AddModelError("", "All fields are required.");
            }
            return View(viewModel);
        }
    }
}