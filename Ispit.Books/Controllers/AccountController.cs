using Ispit.Books.Models;
using Ispit.Books.Models.Binding;
using Ispit.Books.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace Ispit.Books.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _account;
     

        public AccountController(ILogger<AccountController> logger, IAccountService account)
        {
            _logger = logger;
            _account = account;
        }

        public async Task<IActionResult> RegistrationUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationUser(RegistrationBinding model)
        {
           await _account.RegistrationUser(model);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
