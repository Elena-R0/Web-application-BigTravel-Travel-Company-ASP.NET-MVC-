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
    public class PaymentsController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        // GET: Payments
        [Authorize(Roles = "Employes")]
        public ActionResult Index()
        {
            var payment = db.Payment.Include(p => p.Orders).Include(p => p.PayType);
            return View(payment.ToList());
        }

        // GET: Payments/Details/5
        [Authorize(Roles = "Employes")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        [Authorize(Roles = "Employes")]
        public ActionResult Create()
        {
            ViewBag.id_orders = new SelectList(db.Orders, "id_orders", "id_orders");
            ViewBag.Id_PayType = new SelectList(db.PayType, "Id_PayType", "Name_PayType");
            return View();
        }

        // POST: Payments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Create([Bind(Include = "idPayment,id_customer,id_orders,bank_card_num,date_payment,Id_PayType")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payment.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_orders = new SelectList(db.Orders, "id_orders", "id_orders", payment.id_orders);
            ViewBag.Id_PayType = new SelectList(db.PayType, "Id_PayType", "Name_PayType", payment.Id_PayType);
            return View(payment);
        }

        // GET: Payments/Edit/5
        [Authorize(Roles = "Employes")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_orders = new SelectList(db.Orders, "id_orders", "id_orders", payment.id_orders);
            ViewBag.Id_PayType = new SelectList(db.PayType, "Id_PayType", "Name_PayType", payment.Id_PayType);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Edit([Bind(Include = "idPayment,id_customer,id_orders,bank_card_num,date_payment,Id_PayType")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_orders = new SelectList(db.Orders, "id_orders", "id_orders", payment.id_orders);
            ViewBag.Id_PayType = new SelectList(db.PayType, "Id_PayType", "Name_PayType", payment.Id_PayType);
            return View(payment);
        }

        // GET: Payments/Delete/5
        [Authorize(Roles = "Employes")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payment.Find(id);
            db.Payment.Remove(payment);
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
