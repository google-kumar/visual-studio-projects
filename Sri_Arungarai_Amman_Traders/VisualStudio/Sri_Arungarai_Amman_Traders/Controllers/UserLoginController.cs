using Microsoft.AspNetCore.Mvc;
using Sri_Arungarai_Amman_Traders.Models;

namespace Sri_Arungarai_Amman_Traders.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly Sri_Arungarai_Amman_TradersContext db;
        private readonly ISession session_user;
        public UserLoginController(Sri_Arungarai_Amman_TradersContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session_user = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            var result = (from i in db.UserLogins where i.UserName == user.UserName && i.Password == user.Password select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("UserName_user", result.FirstName);
                return RedirectToAction("Index", "User");
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
        public IActionResult Register(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                db.UserLogins.Add(user);
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
