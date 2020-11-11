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
    public class Rebate_cancle_historyController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/Rebate_cancle_history
        public ActionResult Index()
        {
            return View(db.Rebate_cancle_history.ToList());
        }

        // GET: Admin/Rebate_cancle_history/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rebate_cancle_history rebate_cancle_history = db.Rebate_cancle_history.Find(id);
            if (rebate_cancle_history == null)
            {
                return HttpNotFound();
            }
            return View(rebate_cancle_history);
        }

        // GET: Admin/Rebate_cancle_history/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Rebate_cancle_history/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RCID,inwordno,consumer_no,consumer_name,pervious_outstanding,after_rebate_outstanding,difference,difference_percentage,cancledby,cancledon")] Rebate_cancle_history rebate_cancle_history)
        {
            if (ModelState.IsValid)
            {
                db.Rebate_cancle_history.Add(rebate_cancle_history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rebate_cancle_history);
        }

        // GET: Admin/Rebate_cancle_history/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rebate_cancle_history rebate_cancle_history = db.Rebate_cancle_history.Find(id);
            if (rebate_cancle_history == null)
            {
                return HttpNotFound();
            }
            return View(rebate_cancle_history);
        }

        // POST: Admin/Rebate_cancle_history/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RCID,inwordno,consumer_no,consumer_name,pervious_outstanding,after_rebate_outstanding,difference,difference_percentage,cancledby,cancledon")] Rebate_cancle_history rebate_cancle_history)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rebate_cancle_history).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rebate_cancle_history);
        }

        // GET: Admin/Rebate_cancle_history/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rebate_cancle_history rebate_cancle_history = db.Rebate_cancle_history.Find(id);
            if (rebate_cancle_history == null)
            {
                return HttpNotFound();
            }
            return View(rebate_cancle_history);
        }

        // POST: Admin/Rebate_cancle_history/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rebate_cancle_history rebate_cancle_history = db.Rebate_cancle_history.Find(id);
            db.Rebate_cancle_history.Remove(rebate_cancle_history);
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
