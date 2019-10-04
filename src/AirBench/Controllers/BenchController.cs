﻿using System.Web.Mvc;
using AirBench.Models.ViewModels;
using AirBench.Data.Repositories;
using AirBench.Models;

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

        public ActionResult Add()
        {
            var viewModel = new BenchAddViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BenchAddViewModel viewModel)
        {
            var bench = new Bench()
            {
                Description = viewModel.Description,
                Latitude = viewModel.Latitude,
                Longitude = viewModel.Longitude,
                NumberSeats = viewModel.NumberSeats
            };
            // TODO validation
            benchRepo.Add(bench);
            return RedirectToAction("Index");
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
            var review = new Review()
            {
                BenchId = id,
                Description = viewModel.Description,
                Rating = viewModel.Rating
            };

            reviewRepo.Add(review);

            return RedirectToAction("Details", routeValues: new { id = id });
        }
    }
}