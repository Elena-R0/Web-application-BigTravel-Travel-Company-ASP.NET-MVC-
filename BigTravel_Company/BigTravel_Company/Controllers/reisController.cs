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
    public class reisController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        // GET: reis
        [Authorize(Roles = "Employes")]
        public ActionResult Index()
        {
            var reis = db.reis.Include(r => r.Orders);
            return View(reis.ToList());
        }

        // GET: reis/Details/5
        [Authorize(Roles = "Employes")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reis reis = db.reis.Find(id);
            if (reis == null)
            {
                return HttpNotFound();
            }
            return View(reis);
        }

        // GET: reis/Create
        [Authorize(Roles = "Employes")]
        public ActionResult Create()
        {
            ViewBag.id_order = new SelectList(db.Orders, "id_orders", "id_orders");
            return View();
        }

        // POST: reis/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Create([Bind(Include = "id_reis,id_order,Point_departure,Destination,Departure_date,Date_arrival")] reis reis)
        {
            if (ModelState.IsValid)
            {

                db.reis.Add(reis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_order = new SelectList(db.Orders, "id_orders", "id_orders", reis.id_order);
            return View(reis);
        }

        // GET: reis/Edit/5
        [Authorize(Roles = "Employes")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reis reis = db.reis.Find(id);
            if (reis == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_order = new SelectList(db.Orders, "id_orders", "id_orders", reis.id_order);
            return View(reis);
        }

        // POST: reis/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Edit([Bind(Include = "id_reis,id_order,Point_departure,Destination,Departure_date,Date_arrival")] reis reis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_order = new SelectList(db.Orders, "id_orders", "id_orders", reis.id_order);
            return View(reis);
        }

        // GET: reis/Delete/5
        [Authorize(Roles = "Employes")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reis reis = db.reis.Find(id);
            if (reis == null)
            {
                return HttpNotFound();
            }
            return View(reis);
        }

        // POST: reis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult DeleteConfirmed(int id)
        {
            reis reis = db.reis.Find(id);
            db.reis.Remove(reis);
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
