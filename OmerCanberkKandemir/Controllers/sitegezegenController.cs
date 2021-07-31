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
    public class sitegezegenController : Controller
    {
        private infinitextContext db = new infinitextContext();

        // GET: sitegezegen
        public ActionResult Index()
        {
            return View(db.gezegen.ToList());
        }

        // GET: sitegezegen/Details/5
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

        // GET: sitegezegen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sitegezegen/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public ActionResult Create([Bind(Include = "gezegenID,Gezegenadi,GezegenResim")] gezegen gezegen, HttpPostedFileBase GezegenResim)
        {
            if (ModelState.IsValid)
            {
                if (GezegenResim != null)
                {

                    WebImage img = new WebImage(GezegenResim.InputStream);
                    FileInfo imginfo = new FileInfo(GezegenResim.FileName);

                    string gezegenad = GezegenResim.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/gezegen/" + gezegenad);
                    gezegen.GezegenResim = "/Uploads/gezegen/" + gezegenad;
                }
                db.gezegen.Add(gezegen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gezegen);
        }

        // GET: sitegezegen/Edit/5
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

        // POST: sitegezegen/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "gezegenID,Gezegenadi,GezegenResim")] gezegen gezegen, HttpPostedFileBase GezegenResim, int gezegenid)
        {
            if (ModelState.IsValid)
            {
                var k = db.gezegen.Where(x => x.gezegenID == gezegenid).SingleOrDefault();
                if (GezegenResim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.GezegenResim)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.GezegenResim));
                    }
                    WebImage img = new WebImage(GezegenResim.InputStream);
                    FileInfo imginfo = new FileInfo(GezegenResim.FileName);

                    string resimname = GezegenResim.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/gezegen/" + resimname);

                    k.GezegenResim = "/Uploads/gezegen/" + resimname;
                }
                //db.Entry(gezegen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gezegen);
        }

        // GET: sitegezegen/Delete/5
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

        // POST: sitegezegen/Delete/5
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
