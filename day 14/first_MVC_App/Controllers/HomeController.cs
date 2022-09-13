using first_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace first_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["MyName"] = "vishnu";
            return View();
        }

        public ViewResult Sample()
        {
            ViewData["College"] = "SVCE";
            ViewBag.dept = "ECE";
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