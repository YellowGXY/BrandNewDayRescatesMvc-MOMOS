using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrandNewDayRescatesMvc.Models;

namespace BrandNewDayRescatesMvc.Controllers
{
    public class RescatesController : Controller
    {
        private BrandNewDayDbContext db = new BrandNewDayDbContext();

        // GET: Rescates
        public ActionResult Index()
        {
            var rescates = db.Rescates.Include(r => r.Heroe);
            return View(rescates.ToList());
        }

        // GET: Rescates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rescate rescate = db.Rescates.Find(id);
            if (rescate == null)
            {
                return HttpNotFound();
            }
            return View(rescate);
        }

        // GET: Rescates/Create
        public ActionResult Create()
        {
            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Nombre");
            return View();
        }

        // POST: Rescates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RescateId,Titulo,Villano,Resultado,HeroeId")] Rescate rescate)
        {
            if (ModelState.IsValid)
            {
                db.Rescates.Add(rescate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Nombre", rescate.HeroeId);
            return View(rescate);
        }

        // GET: Rescates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rescate rescate = db.Rescates.Find(id);
            if (rescate == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Nombre", rescate.HeroeId);
            return View(rescate);
        }

        // POST: Rescates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RescateId,Titulo,Villano,Resultado,HeroeId")] Rescate rescate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rescate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HeroeId = new SelectList(db.Heroes, "HeroeId", "Nombre", rescate.HeroeId);
            return View(rescate);
        }

        // GET: Rescates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rescate rescate = db.Rescates.Find(id);
            if (rescate == null)
            {
                return HttpNotFound();
            }
            return View(rescate);
        }

        // POST: Rescates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rescate rescate = db.Rescates.Find(id);
            db.Rescates.Remove(rescate);
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
