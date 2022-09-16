using Microsoft.AspNetCore.Mvc;
using Sri_Arungarai_Amman_Traders.Models;
using System.Diagnostics;

namespace Sri_Arungarai_Amman_Traders.Controllers
{
    public class Sri_Arungarai_Amman_TradersController : Controller
    {
        private readonly ILogger<Sri_Arungarai_Amman_TradersController> _logger;

        public Sri_Arungarai_Amman_TradersController(ILogger<Sri_Arungarai_Amman_TradersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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