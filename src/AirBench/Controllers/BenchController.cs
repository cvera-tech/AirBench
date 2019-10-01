using AirBench.Data;
using System.Web.Mvc;
using System.Linq;

namespace AirBench.Controllers
{
    public class BenchController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new BenchContext())
            {
                var benches = context.Benches.ToList();
                return View(benches);
            }
        }
    }
}