using AirBench.Data;
using System.Web.Mvc;
using System.Linq;
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
        
        public ActionResult Index()
        {
            var benches = benchRepo.List();
            return View(benches);
        }

        public ActionResult Add()
        {
            var viewModel = new BenchAddViewModel();
            return View(viewModel);
        }

        [HttpPost]
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
    }
}