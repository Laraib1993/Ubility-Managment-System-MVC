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
    public class partPaymentsController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/partPayments
        public ActionResult Index()
        {
            return View(db.partPayments.ToList());
        }

        // GET: Admin/partPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partPayment partPayment = db.partPayments.Find(id);
            if (partPayment == null)
            {
                return HttpNotFound();
            }
            return View(partPayment);
        }

        // GET: Admin/partPayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/partPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sno,consumer_no,consumer_code,consumer_name,consumer_address,category,area,issue_date,due_date,billing_month,part_payment_into,current_Charges,outstanding_Arrears,part_payemnt_arrears,createdby,createdon,status,barcode")] partPayment partPayment)
        {
            if (ModelState.IsValid)
            {
                db.partPayments.Add(partPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partPayment);
        }

        // GET: Admin/partPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partPayment partPayment = db.partPayments.Find(id);
            if (partPayment == null)
            {
                return HttpNotFound();
            }
            return View(partPayment);
        }

        // POST: Admin/partPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sno,consumer_no,consumer_code,consumer_name,consumer_address,category,area,issue_date,due_date,billing_month,part_payment_into,current_Charges,outstanding_Arrears,part_payemnt_arrears,createdby,createdon,status,barcode")] partPayment partPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partPayment);
        }

        // GET: Admin/partPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partPayment partPayment = db.partPayments.Find(id);
            if (partPayment == null)
            {
                return HttpNotFound();
            }
            return View(partPayment);
        }

        // POST: Admin/partPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            partPayment partPayment = db.partPayments.Find(id);
            db.partPayments.Remove(partPayment);
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
