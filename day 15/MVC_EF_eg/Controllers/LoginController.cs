using Microsoft.AspNetCore.Mvc;
using MVC_EF_eg.Controllers;
using MVC_EF_eg.Models;

namespace MVC_EF_eg.Controllers
{
    public class LoginController : Controller
    {
        private readonly shrivalli_tuition_centerContext db;
        private readonly ISession session;
        public LoginController(shrivalli_tuition_centerContext _db,IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Login(Logintable user)
        { 
            var result=(from i in db.Logintables where i.Username==user.Username && i.Password==user.Password select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("UserName", user.Username);
                return RedirectToAction("Index", "shrivalli_tuition_center");
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
        public IActionResult Register(Logintable user)
        {
            if (ModelState.IsValid)
            {
                db.Logintables.Add(user);
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
