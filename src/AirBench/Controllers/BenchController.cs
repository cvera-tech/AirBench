using AirBench.Data;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    public class BenchController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new BenchContext())
            {
                var benches = context.Benches.Sql;

            }
            return View();
        }
    }
}