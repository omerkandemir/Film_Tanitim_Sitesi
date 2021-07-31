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
    public class sitekarakterController : Controller
    {
        //private infinitextContext db = new infinitextContext();
        private infinitextContext _context;
        public sitekarakterController() {
            _context = new infinitextContext();
        }

        // GET: sitekarakter

        public ActionResult Index()
        {

            var karakter = _context.karakter.Include(k => k.gezegen).Include(k => k.mezhep).Include(k => k.silah).Include(k => k.Tur);
            return View(karakter.ToList());
        }

        // GET: sitekarakter/Details/5
        public ActionResult Details(int? id)
        {
            //var karakter = _context.karakter.SingleOrDefault(c => c.karakterID == id);

            //if (karakter == null)
            //    return HttpNotFound();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karakter karakter = _context.karakter.Include(k => k.gezegen).Include(k => k.mezhep).Include(k => k.silah).Include(k => k.Tur).SingleOrDefault(c => c.karakterID == id);
            //karakter karakter = _context.karakter.Find(id);
            if (karakter == null)
            {
                return HttpNotFound();
            }
            return View(karakter);
        }








        // GET: sitekarakter/Create
        public ActionResult Create()
        {
            ViewBag.gezegenID = new SelectList(_context.gezegen, "gezegenID", "Gezegenadi");
            ViewBag.mezhepID = new SelectList(_context.mezhep, "mezhepID", "Mezhepadi");
            ViewBag.silahID = new SelectList(_context.silah, "silahID", "KullandığıSilah");
            ViewBag.turID = new SelectList(_context.Tur, "turID", "turadi");
            return View();
        }

        // POST: sitekarakter/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "karakterID,baslik,ResimURL,yazi,mezhepID,silahID,gezegenID,turID,usta,padawan,dogduguyil,olumyili")] karakter karakter)
        {
            if (ModelState.IsValid)
            {
                _context.karakter.Add(karakter);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gezegenID = new SelectList(_context.gezegen, "gezegenID", "Gezegenadi", karakter.gezegenID);
            ViewBag.mezhepID = new SelectList(_context.mezhep, "mezhepID", "Mezhepadi", karakter.mezhepID);
            ViewBag.silahID = new SelectList(_context.silah, "silahID", "KullandığıSilah", karakter.silahID);
            ViewBag.turID = new SelectList(_context.Tur, "turID", "turadi", karakter.turID);
            return View(karakter);
        }

        // GET: sitekarakter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karakter karakter = _context.karakter.Find(id);
            if (karakter == null)
            {
                return HttpNotFound();
            }
            ViewBag.gezegenID = new SelectList(_context.gezegen, "gezegenID", "Gezegenadi", karakter.gezegenID);
            ViewBag.mezhepID = new SelectList(_context.mezhep, "mezhepID", "Mezhepadi", karakter.mezhepID);
            ViewBag.silahID = new SelectList(_context.silah, "silahID", "KullandığıSilah", karakter.silahID);
            ViewBag.turID = new SelectList(_context.Tur, "turID", "turadi", karakter.turID);
            return View(karakter);
        }

        // POST: sitekarakter/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "karakterID,baslik,ResimURL,yazi,mezhepID,silahID,gezegenID,turID,usta,padawan,dogduguyil,olumyili")] karakter karakter)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(karakter).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gezegenID = new SelectList(_context.gezegen, "gezegenID", "Gezegenadi", karakter.gezegenID);
            ViewBag.mezhepID = new SelectList(_context.mezhep, "mezhepID", "Mezhepadi", karakter.mezhepID);
            ViewBag.silahID = new SelectList(_context.silah, "silahID", "KullandığıSilah", karakter.silahID);
            ViewBag.turID = new SelectList(_context.Tur, "turID", "turadi", karakter.turID);
            return View(karakter);
        }

        // GET: sitekarakter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karakter karakter = _context.karakter.Find(id);
            if (karakter == null)
            {
                return HttpNotFound();
            }
            return View(karakter);
        }

        // POST: sitekarakter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            karakter karakter = _context.karakter.Find(id);
            _context.karakter.Remove(karakter);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        }
    }
}