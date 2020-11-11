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
    public class consumer_rebateController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/consumer_rebate
        public ActionResult Index()
        {
            return View(db.consumer_rebate.ToList());
        }

        // GET: Admin/consumer_rebate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consumer_rebate consumer_rebate = db.consumer_rebate.Find(id);
            if (consumer_rebate == null)
            {
                return HttpNotFound();
            }
            return View(consumer_rebate);
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
