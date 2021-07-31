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
    public class silahController : Controller
    {
        private infinitextContext db = new infinitextContext();

        // GET: silah
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.silah.ToList());
        }

        // GET: silah/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            silah silah = db.silah.Find(id);
            if (silah == null)
            {
                return HttpNotFound();
            }
            return View(silah);
        }

        // GET: silah/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: silah/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "silahID,KullandığıSilah")] silah silah,HttpPostedFileBase KullandığıSilah)
        {
            if (ModelState.IsValid)
            {
                if (KullandığıSilah != null)
                {

                    WebImage img = new WebImage(KullandığıSilah.InputStream);
                    FileInfo imginfo = new FileInfo(KullandığıSilah.FileName);

                    string ad = KullandığıSilah.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/ısinkilici/" + ad);
                    silah.KullandığıSilah = "/Uploads/ısinkilici/" + ad;
                }
                db.silah.Add(silah);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(silah);
        }

        // GET: silah/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            silah silah = db.silah.Find(id);
            if (silah == null)
            {
                return HttpNotFound();
            }
            return View(silah);
        }

        // POST: silah/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind(Include = "silahID,KullandığıSilah")] silah silah,HttpPostedFileBase KullandığıSilah)
        {
            var k = db.silah.Where(x => x.silahID == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (KullandığıSilah != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.KullandığıSilah)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.KullandığıSilah));
                    }
                    WebImage img = new WebImage(KullandığıSilah.InputStream);
                    FileInfo imginfo = new FileInfo(KullandığıSilah.FileName);

                    string ad = KullandığıSilah.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/ısinkilici/" + ad);
                    k.KullandığıSilah = "/Uploads/ısinkilici/" + ad;
                }


                db.Entry(silah).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(silah);
        }

        // GET: silah/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            silah silah = db.silah.Find(id);
            if (silah == null)
            {
                return HttpNotFound();
            }
            return View(silah);
        }

        // POST: silah/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            silah silah = db.silah.Find(id);
            db.silah.Remove(silah);
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
