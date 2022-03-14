using Newtonsoft.Json;
using PhoneShop.Models;
using PhoneShop.DAL;
using PhoneShop.Repository;
using PhoneShop.Models.Home;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneShop.Controllers
{
    public class HomeController : Controller
    {
        PhoneDBEntities1 db = new PhoneDBEntities1();

        /*Get start*/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            HomeAboutViewModel model = new HomeAboutViewModel();
            return View(model.CreateModel());
        }

        public ActionResult Contact()
        {
            HomeContactViewModel model = new HomeContactViewModel();
            return View(model.CreateModel());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if(db.Registers.Any(x=>x.UserName == register.UserName))
            {
                ViewBag.Notification = "This account already exist";
                return View();
            }
            else
            {
                db.Registers.Add(register);
                db.SaveChanges();

                Session["IdSS"] = register.Id.ToString();
                Session["UserNameSS"] = register.UserName.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Register register)
        {
            var checkLogin = db.Registers.Where(x => x.UserName.Equals(register.UserName) && x.Password.Equals(register.Password)).FirstOrDefault();
            if(checkLogin!=null)
            {
                Session["IdSS"] = register.Id.ToString();
                Session["UserNameSS"] = register.UserName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else if(register.UserName.Equals("Admin") && register.Password.Equals("admin123"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                ViewBag.Notification = "Invalid Username or Password";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Addtocart(int? Id)
        {
            Tbl_Product p = db.Tbl_Product.Where(x => x.ProductId == Id).SingleOrDefault();
            return View(p);
        }
        List<cart> li = new List<cart>();
        [HttpPost]

        public ActionResult Addtocart(Tbl_Product pi, string qty, int Id)
        {
            Tbl_Product p = db.Tbl_Product.Where(x => x.ProductId == Id).SingleOrDefault();

            cart c = new cart();
            c.productid = p.ProductId;
            c.price = (float)p.Price;
            c.qty = Convert.ToInt32(qty);
            c.bill = c.price * c.qty;
            if (TempData["cart"] == null)
            {
                li.Add(c);
                TempData["cart"] = li;
            }
            else
            {
                List<cart> li2 = TempData["cart"] as List<cart>;
                li2.Add(c);
                TempData["cart"] = li2;
            }
            TempData.Keep();

            return RedirectToAction("About");

        }

        public ActionResult checkout()
        {
            return View();
        }

        public ActionResult OrderDetails()
        {
            return View();
        }
    }
}