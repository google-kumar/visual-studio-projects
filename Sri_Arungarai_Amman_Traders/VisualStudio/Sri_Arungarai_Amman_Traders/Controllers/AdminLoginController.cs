using Microsoft.AspNetCore.Mvc;
using Sri_Arungarai_Amman_Traders.Models;

namespace Sri_Arungarai_Amman_Traders.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly Sri_Arungarai_Amman_TradersContext db;
        private readonly ISession session_admin;
        public AdminLoginController(Sri_Arungarai_Amman_TradersContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session_admin = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminLogin user)
        {
            var result = (from i in db.AdminLogins where i.UserName == user.UserName && i.Password == user.Password select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("UserName_admin", result.FirstName);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AdminLogin user)
        {
            if (ModelState.IsValid)
            {
                db.AdminLogins.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();


            return RedirectToAction("Login");
        }
    }
}
