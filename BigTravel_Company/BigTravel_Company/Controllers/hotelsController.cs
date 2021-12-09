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
    public class hotelsController : Controller
    {
        private BigTravelEntities db = new BigTravelEntities();

        // GET: hotels
        [Authorize]
        public ActionResult Index()
        {
            return View(db.hotel.ToList());
        }

        // GET: hotels/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: hotels/Create
        [Authorize(Roles = "Employes")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: hotels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Create(hotel hotel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (db.hotel.Any(u => u.Namehotel== hotel.Namehotel) || db.hotel.Any(u => u.description_hotel == hotel.description_hotel))
                {
                    ModelState.AddModelError("", "Отель с таким названием и описанием существует!");
                    return View(hotel);
                }
                if (image != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    // сохраняем файл в папку в проекте
                    image.SaveAs(Server.MapPath("~/Content/image/hotels/" + fileName));
                    hotel.image = image.FileName;
                }
                db.hotel.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        // GET: hotels/Edit/5
        [Authorize(Roles = "Employes")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: hotels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult Edit([Bind(Include = "id_hotel,Namehotel,image,description_hotel")] hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: hotels/Delete/5
        [Authorize(Roles = "Employes")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employes")]
        public ActionResult DeleteConfirmed(int id)
        {
            hotel hotel = db.hotel.Find(id);
            db.hotel.Remove(hotel);
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
