using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beezilla.Models;
using System.Security.Claims;
namespace Beezilla.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()   
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Redirect("./Identity/Account/Login");
            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "AdminModels");
            }
            else if (User.IsInRole("Keepers"))
            {
                return RedirectToAction("Index", "KeeperModels");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
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