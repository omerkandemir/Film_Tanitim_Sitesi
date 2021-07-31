using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using OmerCanberkKandemir.Models.DataContext;
using OmerCanberkKandemir.Models.Model;

namespace OmerCanberkKandemir.Controllers
{
    public class karakterController : Controller
    {
        //private infinitextContext db = new infinitextContext();
        private infinitextContext _context;
        // GET: karakter
        public karakterController()
        {
            _context = new infinitextContext();
        }
        public ActionResult Index()
        {

            var karakter = _context.karakter.Include(k => k.gezegen).Include(k => k.mezhep).Include(k => k.silah).Include(k => k.Tur);
            return View(karakter.ToList());
            /*return View(db.karakter.Include("gezegen").Include("mezhep").Include("silah").Include("Tur").ToList().OrderByDescending(x => x.karakterID));*/

        }

        // GET: karakter/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            karakter karakter = _context.karakter.Include(k => k.gezegen).Include(k => k.mezhep).Include(k => k.silah).Include(k => k.Tur).SingleOrDefault(c => c.karakterID == id);
            if (karakter == null)
            {
                return HttpNotFound();
            }
            return View(karakter);
        }

        // GET: karakter/Create
        public ActionResult Create()
        {
            _context.karakter.Include(k => k.gezegen).Include(k => k.mezhep).Include(k => k.silah).Include(k => k.Tur);
            ViewBag.gezegenID = new SelectList(_context.gezegen, "gezegenID", "Gezegenadi");
            ViewBag.mezhepID = new SelectList(_context.mezhep, "mezhepID", "Mezhepadi");
            ViewBag.silahID = new SelectList(_context.silah, "silahID", "KullandığıSilah");
            ViewBag.turID = new SelectList(_context.Tur, "turID", "turadi");
            return View();
        }

        // POST: karakter/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "karakterID,baslik,ResimURL,yazi,mezhepID,silahID,gezegenID,turID,usta,padawan,dogduguyil,olumyili")] karakter karakter, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {

                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string ad = ResimURL.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/karakter/" + ad);
                    karakter.ResimURL = "/Uploads/karakter/" + ad;
                }

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

        // GET: karakter/Edit/5
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

        // POST: karakter/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "karakterID,baslik,ResimURL,yazi,mezhepID,silahID,gezegenID,turID,usta,padawan,dogduguyil,olumyili")] karakter karakter, HttpPostedFileBase ResimURL, int id)
        {

            if (ModelState.IsValid)
            {
                var k = _context.karakter.Where(x => x.karakterID == id).SingleOrDefault();
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string resimname = ResimURL.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/karakter/" + resimname);

                    k.ResimURL = "/Uploads/karakter/" + resimname;
                }
                k.baslik = karakter.baslik;
                k.yazi = karakter.yazi;
                k.mezhepID = karakter.mezhepID;
                k.silahID = karakter.silahID;
                k.gezegenID = karakter.gezegenID;
                k.turID = karakter.turID;
                k.usta = karakter.usta;
                k.padawan = karakter.padawan;
                k.gezegenID = karakter.gezegenID;
                k.dogduguyil = karakter.dogduguyil;
                k.olumyili = karakter.olumyili;
                //db.Entry(karakter).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gezegenID = new SelectList(_context.gezegen, "gezegenID", "Gezegenadi", karakter.gezegenID);
            ViewBag.mezhepID = new SelectList(_context.mezhep, "mezhepID", "Mezhepadi", karakter.mezhepID);
            ViewBag.silahID = new SelectList(_context.silah, "silahID", "KullandığıSilah", karakter.silahID);
            ViewBag.turID = new SelectList(_context.Tur, "turID", "turadi", karakter.turID);
            return View(karakter);
        }

        // GET: karakter/Delete/5
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

        // POST: karakter/Delete/5
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