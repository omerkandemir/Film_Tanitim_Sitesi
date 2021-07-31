using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OmerCanberkKandemir.Models.DataContext;
using OmerCanberkKandemir.Models.Model;

namespace OmerCanberkKandemir.Controllers
{
    public class makaleController : Controller
    {
        private infinitextContext db = new infinitextContext();

        // GET: makale
        public ActionResult Index()
        {
            var makale = db.makale.Include(m => m.karakter);
            return View(makale.ToList());
        }

        // GET: makale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            makale makale = db.makale.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }
        public ActionResult information(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karakter karakter = db.karakter.Find(id);
            if (karakter == null)
            {
                return HttpNotFound();
            }
            return View(karakter);
        }
        // GET: makale/Create
        public ActionResult Create()
        {
            ViewBag.karakterID = new SelectList(db.karakter, "karakterID", "baslik");
            return View();
        }

        // POST: makale/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makaleID,baslik,ResimURL,yazi,karakterID")] makale makale)
        {
            if (ModelState.IsValid)
            {
                db.makale.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.karakterID = new SelectList(db.karakter, "karakterID", "baslik", makale.karakterID);
            return View(makale);
        }

        // GET: makale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            makale makale = db.makale.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            ViewBag.karakterID = new SelectList(db.karakter, "karakterID", "baslik", makale.karakterID);
            return View(makale);
        }

        // POST: makale/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makaleID,baslik,ResimURL,yazi,karakterID")] makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.karakterID = new SelectList(db.karakter, "karakterID", "baslik", makale.karakterID);
            return View(makale);
        }

        // GET: makale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            makale makale = db.makale.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            makale makale = db.makale.Find(id);
            db.makale.Remove(makale);
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
