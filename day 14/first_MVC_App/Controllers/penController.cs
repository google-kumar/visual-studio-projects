using Microsoft.AspNetCore.Mvc;
using first_MVC_App.Models;

namespace first_MVC_App.Controllers
{
    public class penController : Controller
    {
        public static List<pen> pens = pen.GetAllPens();
        pen p = new pen();
        
        public string msg() //directly calling it in the web url     /pen/msg
        {
            return "welcome";
        }

        public ContentResult message()
        {
            return Content("welcome");
        }

        public EmptyResult Initialize()
        {
            //pen p = new pen();
            //pen p1 = new pen();
            //pens.Clear();
            //p.penId = 101;
            //p.penName = "apsara";
            //p.penPrice = 20;
            //p1.penId = 102;
            //p1.penName = "natraj";
            //p1.penPrice = 30;
            //pens.Add(p);
            //pens.Add(p1);
            return new EmptyResult();
        }
        public ViewResult penDetail()    //pen/penDetail
        {
            Initialize();
            return View(p);
        }
        public IActionResult penDetails()   //pen/penDetails
        {
            //p.penId = 0;
            //p.penName = "Apsara";
            //p.penPrice = 10;
            return View(pens);
        }

        public IActionResult penDetailss()
        {
            //Initialize();
            return View(pens);
        }

        public IActionResult AddNewPen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPen(pen p)
        {
            pens.Add(p);
            return RedirectToAction("PenDetailss");
        }

        public IActionResult Details(int id)
        {
            p = pens.Where(x => x.penId == id).SingleOrDefault();
            return View(p);
        }

        public IActionResult Edit(int id)
        {
            HttpContext.Session.SetInt32("pid",id);
            p = pens.Where(x => x.penId == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(pen p)
        {
            //int id = p.penId;
            int id = (int)HttpContext.Session.GetInt32("pid");
            pen oldpen= pens.Where(x => x.penId == id).SingleOrDefault();
            //oldpen.penName = p.penName;
            //oldpen.penPrice = p.penPrice;
            pens.Remove(oldpen);
            p.penId = id;
            pens.Add(p);
            return RedirectToAction("PenDetailss");
        }

        public IActionResult Delete(int id)
        {
            p = pens.Where(x => x.penId == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            p= pens.Where(x => x.penId == id).SingleOrDefault();
            pens.Remove(p);
            return RedirectToAction("PenDetailss");
        }

    }
}
