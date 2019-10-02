using AirBench.Data.Repositories;
using AirBench.Models;
using AirBench.Models.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

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
            //var tempPassword = BCrypt.Net.BCrypt.HashPassword("john");
            var viewModel = new AccountLoginViewModel();
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLoginViewModel viewModel)
        {
            if (ModelState.IsValid &&
                ModelState.IsValidField("Username") &&
                ModelState.IsValidField("Password"))
            {
                var authenticated = _repo.Authenticate(viewModel.Username, viewModel.Password);
                if (authenticated)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Username, false);
                    return RedirectToAction("Index", "Bench");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Bench");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var viewModel = new AccountRegisterViewModel();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(AccountRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Username = viewModel.Username,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                };

                var success = _repo.Add(user, viewModel.Password);
                if (success)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Bench");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to register user");
                }
            }

            return View(viewModel);
        }
    }
}