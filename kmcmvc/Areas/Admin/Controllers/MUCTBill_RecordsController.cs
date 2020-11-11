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
    public class MUCTBill_RecordsController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/MUCTBill_Records
        public ActionResult Index()
        {
            return View(db.MUCTBill_Records.ToList());
        }

        // GET: Admin/MUCTBill_Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUCTBill_Records mUCTBill_Records = db.MUCTBill_Records.Find(id);
            if (mUCTBill_Records == null)
            {
                return HttpNotFound();
            }
            return View(mUCTBill_Records);
        }

        // GET: Admin/MUCTBill_Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MUCTBill_Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MUCTBillID,ConsumerNo,Zone,Town,Employee,Createdon,createdby")] MUCTBill_Records mUCTBill_Records)
        {
            if (ModelState.IsValid)
            {
                db.MUCTBill_Records.Add(mUCTBill_Records);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mUCTBill_Records);
        }

        // GET: Admin/MUCTBill_Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUCTBill_Records mUCTBill_Records = db.MUCTBill_Records.Find(id);
            if (mUCTBill_Records == null)
            {
                return HttpNotFound();
            }
            return View(mUCTBill_Records);
        }

        // POST: Admin/MUCTBill_Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MUCTBillID,ConsumerNo,Zone,Town,Employee,Createdon,createdby")] MUCTBill_Records mUCTBill_Records)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mUCTBill_Records).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mUCTBill_Records);
        }

        // GET: Admin/MUCTBill_Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUCTBill_Records mUCTBill_Records = db.MUCTBill_Records.Find(id);
            if (mUCTBill_Records == null)
            {
                return HttpNotFound();
            }
            return View(mUCTBill_Records);
        }

        // POST: Admin/MUCTBill_Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MUCTBill_Records mUCTBill_Records = db.MUCTBill_Records.Find(id);
            db.MUCTBill_Records.Remove(mUCTBill_Records);
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
