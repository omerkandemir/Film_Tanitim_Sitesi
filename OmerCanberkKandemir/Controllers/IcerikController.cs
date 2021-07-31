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
    public class IcerikController : Controller
    {
        //private infinitextContext db = new infinitextContext();
        private infinitextContext _context;
        public IcerikController()
        {
            _context = new infinitextContext();
        }

        // GET: Icerik
        public ActionResult Index()
        {
            var icerik = _context.Icerik.Include(i => i.Kullanici);
            return View(icerik.ToList());
        }

        // GET: Icerik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = _context.Icerik.Include(i => i.Kullanici).SingleOrDefault(c => c.IcerikID == id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            return View(icerik);
        }

        // GET: Icerik/Create
        public ActionResult Create()
        {
            ViewBag.KullaniciID = new SelectList(_context.Kullanici, "KullaniciID", "kullaniciadi");
            return View();
        }

        // POST: Icerik/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IcerikID,Başlık,icerik,ResimURL,KullaniciID")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                _context.Icerik.Add(icerik);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KullaniciID = new SelectList(_context.Kullanici, "KullaniciID", "kullaniciadi", icerik.KullaniciID);
            return View(icerik);
        }

        // GET: Icerik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = _context.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            ViewBag.KullaniciID = new SelectList(_context.Kullanici, "KullaniciID", "kullaniciadi", icerik.KullaniciID);
            return View(icerik);
        }

        // POST: Icerik/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IcerikID,Başlık,icerik,ResimURL,KullaniciID")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(icerik).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KullaniciID = new SelectList(_context.Kullanici, "KullaniciID", "kullaniciadi", icerik.KullaniciID);
            return View(icerik);
        }

        // GET: Icerik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icerik icerik = _context.Icerik.Find(id);
            if (icerik == null)
            {
                return HttpNotFound();
            }
            return View(icerik);
        }

        // POST: Icerik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Icerik icerik = _context.Icerik.Find(id);
            _context.Icerik.Remove(icerik);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //if (disposing)
            //{
                
            //}
            //base.Dispose(disposing);
        }
    }
}
