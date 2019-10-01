using AirBench.Data;
using System.Web.Mvc;
using System.Linq;
using AirBench.Models.ViewModels;
using AirBench.Data.Repositories;

namespace AirBench.Controllers
{
    public class BenchController : Controller
    {
        private IBenchRepository repository;

        public BenchController(IBenchRepository repository)
        {
            this.repository = repository;
        }
        
        public ActionResult Index()
        {
            var benches = repository.GetBenches();
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
            // Query database
            return RedirectToAction("Index");
        }
    }
}