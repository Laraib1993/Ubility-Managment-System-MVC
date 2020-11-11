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
    public class townsController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/towns
        public ActionResult Index()
        {
            return View(db.towns.ToList());
        }

        // POST: Admin/towns
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            using (AdminEntities entities = new AdminEntities())
            {
                List<town> towns = (from town in entities.towns
                                            select town).ToList();
                return Json(towns);
            }
        }

        // GET: Admin/towns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            town town = db.towns.Find(id);
            if (town == null)
            {
                return HttpNotFound();
            }
            return View(town);
        }

        // GET: Admin/towns/Create
        public ActionResult Create()
        {
            ViewBag.ZoneId = new SelectList(db.zones, "ZoneID", "ZoneName");
            return View();
        }

        // POST: Admin/towns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TownID,TownName,AccountStatusID,ZoneId")] town town)
        {

            if (ModelState.IsValid)
            {
                using (db = new AdminEntities())
                {
                    town.AccountStatusID = 1;
                    db.towns.Add(town);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.ZoneId = new SelectList(db.zones, "ZoneID", "ZoneName", town.ZoneId);
            return View(town);
        }

        // GET: towns/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            town town = db.towns.Find(id);

            if (town == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZoneId = new SelectList(db.zones, "ZoneID", "ZoneName");
            return View(town);
        }

        // POST: towns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TownID,TownName,AccountStatusID,ZoneId")] town town)
        {
            if (ModelState.IsValid)
            {
                using (db = new AdminEntities())
                {
                    town.AccountStatusID = 1;
                    db.Entry(town).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            ViewBag.ZoneId = new SelectList(db.zones, "ZoneID", "ZoneName", town.ZoneId);
            return View(town);
        }


        // GET: Admin/towns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            town town = db.towns.Find(id);
            if (town == null)
            {
                return HttpNotFound();
            }
            return View(town);
        }

        // POST: Admin/towns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            town town = db.towns.Find(id);
            db.towns.Remove(town);
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
