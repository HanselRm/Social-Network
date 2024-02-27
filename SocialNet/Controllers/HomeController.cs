using Microsoft.AspNetCore.Mvc;
using SocialNet.MiddledWares;
using SocialNet.Models;
using System.Diagnostics;

namespace SocialNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUser _validateUser;
        public HomeController(ILogger<HomeController> logger, ValidateUser validateUser)
        {
            _logger = logger;
            _validateUser = validateUser;
        }

        public IActionResult Index()
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
