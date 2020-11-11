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
    public class invoicesController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/invoices
        public ActionResult Index()
        {
            return View(db.invoices.ToList());
        }

        // GET: Admin/invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice invoice = db.invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Admin/invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sno,consumer_no,consumer_code,consumer_name,consumer_address,category,area,sqft_sqyd,Storey,zone,town,uc_no,uc_name,block,issue_date,due_date,billing_month,current_Charges,outstanding_Arrears,current_arrears,consumer_service_charges,within_duedate_amount,consumer_surcharge,after_duedate_amount,property_tag,kmc_category,createdby,createdon,status,consumer_checkdigit,billing_period_code,barcode,checkdigit_status,part_payment_createdon,part_payment_createdby,part_payment_arrears,part_payment_into,rebate_status,short_description,Department_Arrears,Arrears_15")] invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Admin/invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice invoice = db.invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Admin/invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sno,consumer_no,consumer_code,consumer_name,consumer_address,category,area,sqft_sqyd,Storey,zone,town,uc_no,uc_name,block,issue_date,due_date,billing_month,current_Charges,outstanding_Arrears,current_arrears,consumer_service_charges,within_duedate_amount,consumer_surcharge,after_duedate_amount,property_tag,kmc_category,createdby,createdon,status,consumer_checkdigit,billing_period_code,barcode,checkdigit_status,part_payment_createdon,part_payment_createdby,part_payment_arrears,part_payment_into,rebate_status,short_description,Department_Arrears,Arrears_15")] invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Admin/invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice invoice = db.invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Admin/invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            invoice invoice = db.invoices.Find(id);
            db.invoices.Remove(invoice);
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
