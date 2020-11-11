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
    public class modify_impactController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/modify_impact
        public ActionResult Index()
        {
            return View(db.modify_impact.ToList());
        }

        // GET: Admin/modify_impact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_impact modify_impact = db.modify_impact.Find(id);
            if (modify_impact == null)
            {
                return HttpNotFound();
            }
            return View(modify_impact);
        }

        // GET: Admin/modify_impact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/modify_impact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "impactID,inword,modification_status,consumer_no,consumer_name,previous_arrears,after_correction,difference,difference_percentage,impact,Description,createdon,createdby,status")] modify_impact modify_impact)
        {
            if (ModelState.IsValid)
            {
                db.modify_impact.Add(modify_impact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modify_impact);
        }

        // GET: Admin/modify_impact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_impact modify_impact = db.modify_impact.Find(id);
            if (modify_impact == null)
            {
                return HttpNotFound();
            }
            return View(modify_impact);
        }

        // POST: Admin/modify_impact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "impactID,inword,modification_status,consumer_no,consumer_name,previous_arrears,after_correction,difference,difference_percentage,impact,Description,createdon,createdby,status")] modify_impact modify_impact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modify_impact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modify_impact);
        }

        // GET: Admin/modify_impact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_impact modify_impact = db.modify_impact.Find(id);
            if (modify_impact == null)
            {
                return HttpNotFound();
            }
            return View(modify_impact);
        }

        // POST: Admin/modify_impact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modify_impact modify_impact = db.modify_impact.Find(id);
            db.modify_impact.Remove(modify_impact);
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
