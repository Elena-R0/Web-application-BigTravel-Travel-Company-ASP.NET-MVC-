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
    public class EmployesController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        // GET: Employes
        [Authorize(Roles = "Employes")]
        public ActionResult Index()
        {
            return View(db.Employes.ToList());
        }



        // GET: Employes/Details/5
        [Authorize(Roles = "Employes")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employes employes = db.Employes.Find(id);
            if (employes == null)
            {
                return HttpNotFound();
            }
            return View(employes);
        }

        // GET: Employes/Create
        [Authorize(Roles = "Employes")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Create([Bind(Include = "id_employes,sername,name,patronymic,date_of_birth,salary,Email,Password,phone")] Employes employes)
        {
            if (ModelState.IsValid)
            {
                if (db.Employes.Any(u => u.Email == employes.Email))
                {
                    ModelState.AddModelError("", "Эта электронная почта уже используется");
                    return View(employes);
                }
                db.Employes.Add(employes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employes);
        }

        // GET: Employes/Edit/5
        [Authorize(Roles = "Employes")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employes employes = db.Employes.Find(id);
            if (employes == null)
            {
                return HttpNotFound();
            }
            return View(employes);
        }

        // POST: Employes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Edit([Bind(Include = "id_employes,sername,name,patronymic,date_of_birth,salary,Email,Password,phone")] Employes employes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employes);
        }

        // GET: Employes/Delete/5
        [Authorize(Roles = "Employes")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employes employes = db.Employes.Find(id);
            if (employes == null)
            {
                return HttpNotFound();
            }
            return View(employes);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employes employes = db.Employes.Find(id);
            db.Employes.Remove(employes);
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
