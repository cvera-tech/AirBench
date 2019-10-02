using AirBench.Data.Repositories;
using AirBench.Models.ViewModels;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository _repo;

        public AccountController(IAccountRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var tempPassword = BCrypt.Net.BCrypt.HashPassword("john");
            var viewModel = new AccountLoginViewModel();
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginViewModel viewModel)
        {
            var authenticated = _repo.Authenticate(viewModel.Username, viewModel.Password);
            return View(viewModel);
        }
    }
}