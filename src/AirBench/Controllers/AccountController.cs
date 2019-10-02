using AirBench.Models.ViewModels;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new AccountLoginViewModel();
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}