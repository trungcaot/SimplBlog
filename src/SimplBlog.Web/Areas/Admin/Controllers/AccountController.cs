using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SimplBlog.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Used for registering as a new user, logging in, and sending password reset emails.
    /// </summary>
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
