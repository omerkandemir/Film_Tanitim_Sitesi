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
    public class mezhepController : Controller
    {
        private infinitextContext db = new infinitextContext();

        // GET: mezhep
        public ActionResult Index()
        {
            return View(db.mezhep.ToList());
        }

        // GET: mezhep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mezhep mezhep = db.mezhep.Find(id);
            if (mezhep == null)
            {
                return HttpNotFound();
            }
            return View(mezhep);
        }

        // GET: mezhep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mezhep/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mezhepID,Mezhepadi")] mezhep mezhep)
        {
            if (ModelState.IsValid)
            {
                db.mezhep.Add(mezhep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mezhep);
        }

        // GET: mezhep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mezhep mezhep = db.mezhep.Find(id);
            if (mezhep == null)
            {
                return HttpNotFound();
            }
            return View(mezhep);
        }

        // POST: mezhep/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mezhepID,Mezhepadi")] mezhep mezhep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mezhep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mezhep);
        }

        // GET: mezhep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mezhep mezhep = db.mezhep.Find(id);
            if (mezhep == null)
            {
                return HttpNotFound();
            }
            return View(mezhep);
        }

        // POST: mezhep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mezhep mezhep = db.mezhep.Find(id);
            db.mezhep.Remove(mezhep);
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
