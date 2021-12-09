using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rotativa;
using BigTravel_Company.Models;

namespace BigTravel_Company.Controllers
{
    public class OrdersController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        // GET: Orders
        [Authorize(Roles = "Employes")]
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employes).Include(o => o.Order_status).Include(o => o.Vouchers);
            return View(orders.ToList());
        }


        // GET: Orders/Details/5
        [Authorize(Roles = "Employes")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }
        public ActionResult PrintIndex()
        {
            return PartialView(db.Orders.ToList());
        }

        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Print()
        {
            return new ViewAsPdf
            {
                ViewName = "PrintIndex",
                PageSize = Rotativa.Options.Size.A4,
                Model = db.Orders.ToList()
               // CustomSwitches = $"--header-html \"{Url.Action("Header", "Orders", new { area = "" }, "http")}\""
            };
        }

        // GET: Orders/Create
        [Authorize]

        public ActionResult Create(int? id)
        {
            ViewBag.id_customer = new SelectList(db.Customer, "id_customer", "Series");
            ViewBag.id_employes = new SelectList(db.Employes, "id_employes", "sername");
            ViewBag.idOrder_status = new SelectList(db.Order_status, "idOrder_status", "NameStatus");
            if (id != null)
                ViewBag.id_vouchers = new SelectList(db.Vouchers, "id_vouchers", "name_vouchers", id); //чет вертый параметр - это выбранный элемент
            else
                ViewBag.id_vouchers = new SelectList(db.Vouchers, "id_vouchers", "name_vouchers");

            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "id_orders,id_customer,id_employes,id_vouchers,Date_registration,Number,idOrder_status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_customer = new SelectList(db.Customer, "id_customer", "Series", orders.id_customer);
            ViewBag.id_employes = new SelectList(db.Employes, "id_employes", "sername", orders.id_employes);
            ViewBag.idOrder_status = new SelectList(db.Order_status, "idOrder_status", "NameStatus", orders.idOrder_status);
            ViewBag.id_vouchers = new SelectList(db.Vouchers, "id_vouchers", "name_vouchers", orders.id_vouchers);
            return View(orders);
        }

        // GET: Orders/Edit/5\
        [Authorize(Roles = "Employes")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_customer = new SelectList(db.Customer, "id_customer", "Series", orders.id_customer);
            ViewBag.id_employes = new SelectList(db.Employes, "id_employes", "sername", orders.id_employes);
            ViewBag.idOrder_status = new SelectList(db.Order_status, "idOrder_status", "NameStatus", orders.idOrder_status);
            ViewBag.id_vouchers = new SelectList(db.Vouchers, "id_vouchers", "name_vouchers", orders.id_vouchers);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Edit([Bind(Include = "id_orders,id_customer,id_employes,id_vouchers,Date_registration,Number,idOrder_status")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_customer = new SelectList(db.Customer, "id_customer", "Series", orders.id_customer);
            ViewBag.id_employes = new SelectList(db.Employes, "id_employes", "sername", orders.id_employes);
            ViewBag.idOrder_status = new SelectList(db.Order_status, "idOrder_status", "NameStatus", orders.idOrder_status);
            ViewBag.id_vouchers = new SelectList(db.Vouchers, "id_vouchers", "name_vouchers", orders.id_vouchers);
            return View(orders);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Employes")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
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
