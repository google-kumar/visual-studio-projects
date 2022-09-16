using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sri_Arungarai_Amman_Traders.Models;

namespace Sri_Arungarai_Amman_Traders.Controllers
{
    public static class BillAmount
    {
        public static double temp = 0;
    }
    public class AdminController : Controller
    {
        private readonly Sri_Arungarai_Amman_TradersContext db;
        
        
        

        public AdminController(Sri_Arungarai_Amman_TradersContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            ViewBag.BillAmount = 0;
            BillAmount.temp = 0;

            ViewBag.username = HttpContext.Session.GetString("UserName_admin");
            if (ViewBag.username != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        public IActionResult SeedsIndex()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_admin");
            if (ViewBag.username != null)
            {
                return View(db.Seeds.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }

        }

        public IActionResult SeedsCreate()
        {
            //var result = db.Tuitors.ToList();
            //ViewBag.Tuitor = new SelectList(result, "TuitorName", "TuitorName"); // ViewBag.R_no = new SelectList(result, "R_no", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult SeedsCreate(Seed s)
        {
            if (ModelState.IsValid)
            {
                //s.PurchaseDate.Reverse();
                db.Seeds.Add(s);
                db.SaveChanges();
                return RedirectToAction("SeedsIndex");
            }
            else 
            {
                return View();
            }
            
        }

        public IActionResult SeedsEdit(int id)
        {

            Seed s = db.Seeds.Find(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult SeedsEdit(Seed s)
        {
            db.Seeds.Update(s);
            db.SaveChanges();
            return RedirectToAction("SeedsIndex");
        }

        
        public IActionResult SeedsDelete(int id)
        {
            //var result = db.Seeds.Include(p => p.TuitorNavigation);
            Seed s = db.Seeds.Where(p => p.ProductId == id).Select(p => p).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        [ActionName("SeedsDelete")]
        public IActionResult SeedsDeletee(int id)
        {
            Seed s = db.Seeds.Find(id);
            db.Seeds.Remove(s);
            db.SaveChanges();
            return RedirectToAction("SeedsIndex");
        }















        public IActionResult FertilizersIndex()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_admin");
            if (ViewBag.username != null)
            {
                return View(db.Fertilizers.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }

        }

        public IActionResult FertilizersCreate()
        {
            //var result = db.Tuitors.ToList();
            //ViewBag.Tuitor = new SelectList(result, "TuitorName", "TuitorName"); // ViewBag.R_no = new SelectList(result, "R_no", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult FertilizersCreate(Fertilizer s)
        {
            if (ModelState.IsValid)
            {
                //s.PurchaseDate.Reverse();
                db.Fertilizers.Add(s);
                db.SaveChanges();
                return RedirectToAction("FertilizersIndex");
            }
            else
            {
                return View();
            }

        }

        public IActionResult FertilizersEdit(int id)
        {

            Fertilizer s = db.Fertilizers.Find(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult FertilizersEdit(Fertilizer s)
        {
            db.Fertilizers.Update(s);
            db.SaveChanges();
            return RedirectToAction("FertilizersIndex");
        }


        public IActionResult FertilizersDelete(int id)
        {
            //var result = db.Seeds.Include(p => p.TuitorNavigation);
            Fertilizer s = db.Fertilizers.Where(p => p.ProductId == id).Select(p => p).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        [ActionName("FertilizersDelete")]
        public IActionResult FertilizersDeletee(int id)
        {
            Fertilizer s = db.Fertilizers.Find(id);
            db.Fertilizers.Remove(s);
            db.SaveChanges();
            return RedirectToAction("FertilizersIndex");
        }

















        public IActionResult ChemicalsIndex()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_admin");
            if (ViewBag.username != null)
            {
                return View(db.Chemicals.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }

        }

        public IActionResult ChemicalsCreate()
        {
            //var result = db.Tuitors.ToList();
            //ViewBag.Tuitor = new SelectList(result, "TuitorName", "TuitorName"); // ViewBag.R_no = new SelectList(result, "R_no", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult ChemicalsCreate(Chemical s)
        {
            if (ModelState.IsValid)
            {
                //s.PurchaseDate.Reverse();
                db.Chemicals.Add(s);
                db.SaveChanges();
                return RedirectToAction("ChemicalsIndex");
            }
            else
            {
                return View();
            }

        }

        public IActionResult ChemicalsEdit(int id)
        {

            Chemical s = db.Chemicals.Find(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult ChemicalsEdit(Chemical s)
        {
            db.Chemicals.Update(s);
            db.SaveChanges();
            return RedirectToAction("ChemicalsIndex");
        }


        public IActionResult ChemicalsDelete(int id)
        {
            //var result = db.Seeds.Include(p => p.TuitorNavigation);
            Chemical s = db.Chemicals.Where(p => p.ProductId == id).Select(p => p).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        [ActionName("ChemicalsDelete")]
        public IActionResult ChemicalsDeletee(int id)
        {
            Chemical s = db.Chemicals.Find(id);
            db.Chemicals.Remove(s);
            db.SaveChanges();
            return RedirectToAction("ChemicalsIndex");
        }














        public IActionResult BillsIndex()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName_admin");
            if (ViewBag.username != null)
            {
                return View(db.Bills.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }

        }


        public ActionResult Billing()
        {
            //var result = db.ProductTypes.ToList();
            //ViewBag.Tuitor = new SelectList(result, "TuitorName", "TuitorName");
            //var u = new ProductTypes();
            //u.ProductTypeId = new SelectList(new List<SelectListItem>
            //{
            //      new SelectListItem { Text = "Homeowner", Value = ().ToString()},
            //      new SelectListItem { Text = "Contractor", Value = ((int)UserType.Contractor).ToString()},
            //},    "Value", "Text");
            

            return View();
        }

        [HttpPost]
        public ActionResult Billing(string ProductType, string ProductName, string Quantity, string Add)
        {
            double a = double.Parse(Quantity);
           
            double c = 0;
            switch (Add)
            {
                case "Continue":
                    {
                        if (ProductType == "Seeds")
                        {
                            Seed s = db.Seeds.Where(p => p.ProductName == ProductName).Select(p => p).SingleOrDefault();
                            //db.Seeds.Update
                            var result = db.Seeds.SingleOrDefault(b => b.ProductName == ProductName);

                            if (result.QuantityAvailable < a)
                            { 
                                //error message quantity not available
                            }
                            else
                            {
                                c = s.Price * a;


                                if (result != null)
                                {
                                    result.QuantityAvailable = result.QuantityAvailable - a;
                                    db.SaveChanges();
                                }
                            }

                            
                        }
                        else if (ProductType == "Chemicals")
                        {
                            Chemical s = db.Chemicals.Where(p => p.ProductName == ProductName).Select(p => p).SingleOrDefault();
                            var result = db.Chemicals.SingleOrDefault(b => b.ProductName == ProductName);
                            if (result.QuantityAvailable < a)
                            {
                                //error message quantity not available
                            }
                            else
                            {
                                c = s.Price * a;
                                if (result != null)
                                {
                                    result.QuantityAvailable = result.QuantityAvailable - a;
                                    db.SaveChanges();
                                }
                            }

                            
                        }
                        else
                        {
                            Fertilizer s = db.Fertilizers.Where(p => p.ProductName == ProductName).Select(p => p).SingleOrDefault();
                            var result = db.Fertilizers.SingleOrDefault(b => b.ProductName == ProductName);

                            if (result.QuantityAvailable < a)
                            {
                                //error message quantity not available
                            }
                            else
                            {
                                c = s.Price * a;
                                if (result != null)
                                {
                                    result.QuantityAvailable = result.QuantityAvailable - a;
                                    db.SaveChanges();
                                }
                            }
                        }

                        break;
                    }
                    
                    
                case "Stop":
                    {
                        return RedirectToAction("BillsCreate");
                    }
                    
                    break;
                
            }
            
            BillAmount.temp = BillAmount.temp + c;
            ViewBag.BillAmount = BillAmount.temp;
            TempData.Clear();
            TempData.Add("BillAmount",BillAmount.temp.ToString());
            return View();
        }



        public IActionResult BillsCreate()
        {
            //var result = db.Tuitors.ToList();
            //ViewBag.Tuitor = new SelectList(result, "TuitorName", "TuitorName"); // ViewBag.R_no = new SelectList(result, "R_no", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult BillsCreate(Bill s)
        {
            s.BillAmount=BillAmount.temp;
            if (ModelState.IsValid)
            {
                //s.PurchaseDate.Reverse();
                db.Bills.Add(s);
                db.SaveChanges();
                return RedirectToAction("BillsIndex");
            }
            else
            {
                return View();
            }

        }


    }
}
