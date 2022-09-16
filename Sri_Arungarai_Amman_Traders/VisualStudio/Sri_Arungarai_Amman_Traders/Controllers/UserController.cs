using Microsoft.AspNetCore.Mvc;
using Sri_Arungarai_Amman_Traders.Models;

namespace Sri_Arungarai_Amman_Traders.Controllers
{
    public class UserController : Controller
    {
        private readonly Sri_Arungarai_Amman_TradersContext db;

        public UserController(Sri_Arungarai_Amman_TradersContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {

            ViewBag.username = HttpContext.Session.GetString("UserName_user");
            if (ViewBag.username != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }
        }

        public IActionResult SeedsIndex()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_user");
            if (ViewBag.username != null)
            {
                return View(db.Seeds.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }

        }

        public IActionResult FertilizersIndex()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_user");
            if (ViewBag.username != null)
            {
                return View(db.Fertilizers.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }

        }

        public IActionResult ChemicalsIndex()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_user");
            if (ViewBag.username != null)
            {
                return View(db.Chemicals.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }

        }

        public IActionResult BillsIndex()
        {

            ViewBag.username = HttpContext.Session.GetString("UserName_user");
            if (ViewBag.username != null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }
        }

        [HttpPost]
        public IActionResult BillsIndex(Bill b)
        {
            //if (ModelState.IsValid)
            //{
            //    //s.PurchaseDate.Reverse();
                //Bill s = db.Bills.Find(id);
                
                //return View(s);

                return RedirectToAction("BillssIndex", new {id=b.BillNo });
            //}
            //else
            //{
            //    return RedirectToAction("BillsIndex");
            //}

        }

        public IActionResult BillssIndex(int id)
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_user");
            if (ViewBag.username != null)
            {
                //Bill s = db.Bills.Find(id);
                //return View(s);
                //List<Bill> bills = db.Bills.ToList().Where(p => p.BillNo == id);
                return View(db.Bills.ToList().Where(p => p.BillNo == id));

            }
            else
            {
                return RedirectToAction("Login", "UserLogin");
            }

        }

       

    }
}
