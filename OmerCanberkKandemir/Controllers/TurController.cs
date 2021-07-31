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
    public class TurController : Controller
    {
        private infinitextContext db = new infinitextContext();

        // GET: Tur
        public ActionResult Index()
        {
            return View(db.Tur.ToList());
        }

        // GET: Tur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Tur.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // GET: Tur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tur/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "turID,turadi")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                db.Tur.Add(tur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tur);
        }

        // GET: Tur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Tur.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // POST: Tur/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "turID,turadi")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tur);
        }

        // GET: Tur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tur tur = db.Tur.Find(id);
            if (tur == null)
            {
                return HttpNotFound();
            }
            return View(tur);
        }

        // POST: Tur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tur tur = db.Tur.Find(id);
            db.Tur.Remove(tur);
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
