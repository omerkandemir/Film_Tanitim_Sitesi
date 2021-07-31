using OmerCanberkKandemir.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerCanberkKandemir.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        infinitextContext db = new infinitextContext();
        public ActionResult Index()
        {
            var sorgu = db.Admin.ToList();
            return View(sorgu);
        }
    }
}