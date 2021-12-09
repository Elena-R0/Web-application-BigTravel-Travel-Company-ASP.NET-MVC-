using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BigTravel_Company.Models;


namespace BigTravel_Company.Controllers
{
    public class HomeController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        //public class FilListViewModel
        //{
        //    public IEnumerable<Vouchers> Vouchers { get; set; }
        //    public SelectList Name_country { get; set; }

        //}

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (TempData["Error"] != null)
                ViewBag.Error = TempData["Error"]; 
            var vouchers = db.Vouchers.Include(v => v.hotel).Include(v => v.Route);
            return View(vouchers.Take(3).ToList());
        }

        [AllowAnonymous]
        public ActionResult AccessError()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Sign()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("AccessError");
            else
                return PartialView();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Sign(string email, string password, string returnUrl) 
        {
            Customer customer = db.Customer.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
            Employes employes = db.Employes.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
            if (customer != null || employes != null)
            {
                FormsAuthentication.SetAuthCookie(email, false);
                Session["Menu"] = null;
                if (customer != null)
                    return RedirectToAction(/*"Account", "Customers"*/ "Index"); //страница заказчик 
                if (employes != null)
                    return RedirectToAction(/*"Account", "Employes"*/ "Index"); //страница сотрудника 
                //if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                //        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                //    return Redirect(returnUrl);
                return PartialView(); //если вдруг какая-то ошибка 
            }
            else
                {
                    TempData["Error"] = "Пользователя с таким логином и паролем не существует";
                    return RedirectToAction("Index");
                }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}