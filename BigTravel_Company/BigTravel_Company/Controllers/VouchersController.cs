using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BigTravel_Company.Models;


namespace BigTravel_Company.Controllers
{
    public class VouchersController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        public int ID { get; private set; }

        // GET: Vouchers

        public ActionResult Index()
        {

            var vouchers = db.Vouchers.Include(v => v.hotel).Include(v => v.Route);
            return View(vouchers.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? id_country, DateTime? Departure_date, DateTime? Date_arrival)
        {
            IQueryable<Vouchers> vouch = db.Vouchers.Include(p => p.Route);
            if (id_country != null && id_country != 0)
            {
                vouch = vouch.Where(p => p.Route.id_country == id_country);
            }
            if (Departure_date != null)
            {
                vouch = vouch.Where(p => p.Departure_date == Departure_date);
            }
            if (Date_arrival != null)
            {
                vouch = vouch.Where(p => p.Date_arrival == Date_arrival);
            }
            

            return View(vouch.ToList());
        }
        public ActionResult Search()
        {
            ViewBag.id_country = new SelectList(db.Country, "id_country", "Name_country");
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int? id_country, DateTime? Departure_date, DateTime? Date_arrival)
        {
            IQueryable<Vouchers> vouch = db.Vouchers.Include(p => p.Route.id_country);
            if (id_country != null && id_country != 0)
            {
                vouch = vouch.Where(p => p.Route.id_country == id_country);
            }
            if (Departure_date != null)
            {
                vouch = vouch.Where(p => p.Departure_date == Departure_date);
            }
            if (Date_arrival != null)
            {
                vouch = vouch.Where(p => p.Date_arrival == Date_arrival);
            }

            return View(vouch);


            //if (!String.IsNullOrEmpty(position) && !position.Equals("Все"))
            //{
            //    vouch = vouch.Where(p => p.Position == position);
            //}

            //List<Team> teams = db.Teams.ToList();
            //// устанавливаем начальный элемент, который позволит выбрать всех
            //teams.Insert(0, new Team { Name = "Все", Id = 0 });

            //PlayersListViewModel plvm = new PlayersListViewModel
            //{
            //    Players = players.ToList(),
            //    Teams = new SelectList(teams, "Id", "Name"),
            //    Positions = new SelectList(new List<string>()
            //{
            //    "Все",
            //    "Нападающий",
            //    "Полузащитник",
            //    "Защитник",
            //    "Вратарь"
            //})
            //};
            //return View(plvm);
        }

        // GET: Vouchers/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vouchers vouchers = db.Vouchers.Find(id);
            if (vouchers == null)
            {
                return HttpNotFound();
            }
            return View(vouchers);
        }

        // GET: Vouchers/Create
        [Authorize(Roles = "Employes")]
        public ActionResult Create()
        {
            ViewBag.id_hotel = new SelectList(db.hotel, "id_hotel", "Namehotel");
            ViewBag.id_route = new SelectList(db.Route, "id_route", "Place");
            return View();
        }

        // POST: Vouchers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]

        public ActionResult Create(Vouchers vouchers, HttpPostedFileBase image)
        {

            ViewBag.id_hotel = new SelectList(db.hotel, "id_hotel", "Namehotel", vouchers.id_hotel);
            ViewBag.id_route = new SelectList(db.Route, "id_route", "Place", vouchers.id_route);
            if (ModelState.IsValid)
            {

                if (db.Vouchers.Any(u => u.name_vouchers == vouchers.name_vouchers || u.Information_vouchers == vouchers.Information_vouchers))
                {
                    ModelState.AddModelError("", "Тур с таким названием и описанием существует!");
                    return View(vouchers);
                }
                if (image != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    // сохраняем файл в папку в проекте
                    image.SaveAs(Server.MapPath("~/Content/image/hotels/" + fileName));
                    vouchers.image = image.FileName;
                }
                db.Vouchers.Add(vouchers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vouchers);
        }
        [Authorize(Roles = "Employes")]

        // GET: Vouchers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vouchers vouchers = db.Vouchers.Find(id);
            if (vouchers == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_hotel = new SelectList(db.hotel, "id_hotel", "Namehotel", vouchers.id_hotel);
            ViewBag.id_route = new SelectList(db.Route, "id_route", "Place", vouchers.id_route);
            return View(vouchers);
        }

        // POST: Vouchers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]

        public ActionResult Edit(Vouchers vouchers, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    // сохраняем файл в папку в проекте
                    image.SaveAs(Server.MapPath("~/Content/image/hotels/" + fileName));
                    vouchers.image = image.FileName;
                }
                db.Entry(vouchers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_hotel = new SelectList(db.hotel, "id_hotel", "Namehotel", vouchers.id_hotel);
            ViewBag.id_route = new SelectList(db.Route, "id_route", "Place", vouchers.id_route);
            return View(vouchers);
        }

        // GET: Vouchers/Delete/5
        [Authorize(Roles = "Employes")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vouchers vouchers = db.Vouchers.Find(id);
            if (vouchers == null)
            {
                return HttpNotFound();
            }
            return View(vouchers);
        }

        // POST: Vouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]

        public ActionResult DeleteConfirmed(int id)
        {
            Vouchers vouchers = db.Vouchers.Find(id);
            db.Vouchers.Remove(vouchers);
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
