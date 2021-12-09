using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BigTravel_Company.Models;

namespace BigTravel_Company.Controllers
{
    public class CountriesController : Controller
    {
     
        private BigTravelEntities db = new BigTravelEntities();
   
        [Authorize]
        // GET: Countries
        public ActionResult Index()
        {
            return View(db.Country.ToList());
        }

       
        [Authorize]
        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        [Authorize(Roles = "Employes")]

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]


        public ActionResult Create(Country country, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (db.Country.Any(u => u.Name_country == country.Name_country) || db.Country.Any(u => u.Description_country == country.Description_country))
                {
                    ModelState.AddModelError("", "Страна с таким названием или описанием существует!");
                    return View(country);
                }
                if (image != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    // сохраняем файл в папку в проекте
                    image.SaveAs(Server.MapPath("~/Content/image/country/" + fileName));
                    country.image = image.FileName;
                }
                db.Country.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        [Authorize(Roles = "Employes")]


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Employes")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    // сохраняем файл в папку в проекте
                    image.SaveAs(Server.MapPath("~/Content/image/country/" + fileName));
                    country.image = image.FileName;
                }
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        [Authorize(Roles = "Employes")]

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }


     
        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]


        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Country.Find(id);
            db.Country.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
