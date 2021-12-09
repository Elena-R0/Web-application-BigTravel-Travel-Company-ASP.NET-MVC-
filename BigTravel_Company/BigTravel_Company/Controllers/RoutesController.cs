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
    public class RoutesController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        // GET: Routes
        public ActionResult Index()
        {
            var route = db.Route.Include(r => r.Country);
            return View(route.ToList());
        }

        //public ActionResult Index(int? country, DateTime? jj)
        //{
        //    var route = db.Route.Include(r => r.Country);
        //    return View(route.ToList());
        //} 
        [Authorize]
        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Routes/Create
        [Authorize(Roles = "Employes")]
        public ActionResult Create()
        {
            ViewBag.id_country = new SelectList(db.Country, "id_country", "Name_country");

            return View();
        }

        // POST: Routes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Create(Route route, HttpPostedFileBase Place_image)
        {
            ViewBag.id_country = new SelectList(db.Country, "id_country", "Name_country");

            if (ModelState.IsValid)
            {
                if (db.Route.Any(u => u.Place == route.Place) || db.Route.Any(u => u.Place_description == route.Place_description))
                {
                    ModelState.AddModelError("", "Маршрут с таким названием и описанием существует!");
                    return View(route);
                }
                if (Place_image != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(Place_image.FileName);
                    // сохраняем файл в папку в проекте
                    Place_image.SaveAs(Server.MapPath("~/Content/image/route/" + fileName));
                    route.Place_image = Place_image.FileName;
                }
                db.Route.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_country = new SelectList(db.Country, "id_country", "Name_country", route.id_country);
            return View(route);
        }

        // GET: Routes/Edit/5
        [Authorize(Roles = "Employes")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_country = new SelectList(db.Country, "id_country", "Name_country", route.id_country);
            return View(route);
        }

        // POST: Routes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Edit(Route route, HttpPostedFileBase Place_image)
        {
            if (ModelState.IsValid)
            {
                if (Place_image != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(Place_image.FileName);
                    // сохраняем файл в папку в проекте
                    Place_image.SaveAs(Server.MapPath("~/Content/image/route/" + fileName));
                    route.Place_image = Place_image.FileName;
                }
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_country = new SelectList(db.Country, "id_country", "Name_country", route.id_country);
            return View(route);
        }

        // GET: Routes/Delete/5
        [Authorize(Roles = "Employes")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Route.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Route.Find(id);
            db.Route.Remove(route);
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
