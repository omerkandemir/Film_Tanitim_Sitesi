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
    public class gezegenController : Controller
    {
        private infinitextContext db = new infinitextContext();

        // GET: gezegen
        public ActionResult Index()
        {
            return View(db.gezegen.ToList());
        }

        // GET: gezegen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gezegen gezegen = db.gezegen.Find(id);
            if (gezegen == null)
            {
                return HttpNotFound();
            }
            return View(gezegen);
        }

        // GET: gezegen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gezegen/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gezegenID,Gezegenadi,GezegenResim")] gezegen gezegen)
        {
            if (ModelState.IsValid)
            {
                db.gezegen.Add(gezegen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gezegen);
        }

        // GET: gezegen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gezegen gezegen = db.gezegen.Find(id);
            if (gezegen == null)
            {
                return HttpNotFound();
            }
            return View(gezegen);
        }

        // POST: gezegen/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gezegenID,Gezegenadi,GezegenResim")] gezegen gezegen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gezegen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gezegen);
        }

        // GET: gezegen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gezegen gezegen = db.gezegen.Find(id);
            if (gezegen == null)
            {
                return HttpNotFound();
            }
            return View(gezegen);
        }

        // POST: gezegen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gezegen gezegen = db.gezegen.Find(id);
            db.gezegen.Remove(gezegen);
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
