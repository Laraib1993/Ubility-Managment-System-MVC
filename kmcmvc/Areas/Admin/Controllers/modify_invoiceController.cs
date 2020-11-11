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
    public class modify_invoiceController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/modify_invoice
        public ActionResult Index()
        {
            return View(db.modify_invoice.ToList());
        }

        // GET: Admin/modify_invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_invoice modify_invoice = db.modify_invoice.Find(id);
            if (modify_invoice == null)
            {
                return HttpNotFound();
            }
            return View(modify_invoice);
        }

        // GET: Admin/modify_invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/modify_invoice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sno,inword,modification_status,consumer_no,previous_category,previous_area,previous_Storey,previous_current_Charges,previous_outstanding_Arrears,new_category,new_area,new_storey,new_current_Charge,new_outstanding_Arrears,zone,town,billing_month,consumer_surcharge,createdby,createdon,description,status")] modify_invoice modify_invoice)
        {
            if (ModelState.IsValid)
            {
                db.modify_invoice.Add(modify_invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modify_invoice);
        }

        // GET: Admin/modify_invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_invoice modify_invoice = db.modify_invoice.Find(id);
            if (modify_invoice == null)
            {
                return HttpNotFound();
            }
            return View(modify_invoice);
        }

        // POST: Admin/modify_invoice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sno,inword,modification_status,consumer_no,previous_category,previous_area,previous_Storey,previous_current_Charges,previous_outstanding_Arrears,new_category,new_area,new_storey,new_current_Charge,new_outstanding_Arrears,zone,town,billing_month,consumer_surcharge,createdby,createdon,description,status")] modify_invoice modify_invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modify_invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modify_invoice);
        }

        // GET: Admin/modify_invoice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_invoice modify_invoice = db.modify_invoice.Find(id);
            if (modify_invoice == null)
            {
                return HttpNotFound();
            }
            return View(modify_invoice);
        }

        // POST: Admin/modify_invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modify_invoice modify_invoice = db.modify_invoice.Find(id);
            db.modify_invoice.Remove(modify_invoice);
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
