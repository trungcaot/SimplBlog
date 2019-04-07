using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SimplBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ILogger _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            _logger.LogInformation("Login");

            return View();
        }

        public IActionResult Register()
        {
            _logger.LogInformation("Register");

            return View();
        }

        public IActionResult ForgotPassword()
        {
            _logger.LogInformation("ForgotPassword");

            return View();
        }
    }
}
