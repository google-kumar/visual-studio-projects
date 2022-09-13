using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_EF_eg.Models;

namespace MVC_EF_eg.Controllers
{
    public class shrivalli_tuition_centerController : Controller
    {
        
        private readonly shrivalli_tuition_centerContext db;

        public shrivalli_tuition_centerController(shrivalli_tuition_centerContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName");
            if (ViewBag.username != null)
            {
                var result = db.Students.Include(p => p.TuitorNavigation);
                return View(result.ToList());
            }
            else 
            {
                return RedirectToAction("Login", "Login");
            }
            
        }

        public IActionResult Create()
        {
            var result = db.Tuitors.ToList();
            ViewBag.Tuitor = new SelectList(result,"TuitorName", "TuitorName"); // ViewBag.R_no = new SelectList(result, "R_no", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            Student s= db.Students.Find(id);
            var result = db.Tuitors.ToList();
            ViewBag.Tuitor = new SelectList(result, "TuitorName", "TuitorName");

            return View(s);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            db.Students.Update(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var result = db.Students.Include(p => p.TuitorNavigation);
            Student s = result.Where(p => p.RollNo == id).Select(p => p).SingleOrDefault();
            return View(s);
        }

        public IActionResult Delete(int id)
        {
            var result = db.Students.Include(p => p.TuitorNavigation);
           Student s = result.Where(p => p.RollNo == id).Select(p => p).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteWithId(int id)
        {
            Student p = db.Students.Find(id);
            db.Students.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
