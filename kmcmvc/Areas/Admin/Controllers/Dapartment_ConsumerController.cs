using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kmcmvc.Areas.Admin.Data;

namespace kmcmvc.Areas.Admin.Controllers
{
    public class Dapartment_ConsumerController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/Dapartment_Consumer
        public ActionResult Index()
        {
            return View(db.Dapartment_Consumer.ToList());
        }

        // GET: Admin/Dapartment_Consumer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dapartment_Consumer dapartment_Consumer = db.Dapartment_Consumer.Find(id);
            if (dapartment_Consumer == null)
            {
                return HttpNotFound();
            }
            return View(dapartment_Consumer);
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
