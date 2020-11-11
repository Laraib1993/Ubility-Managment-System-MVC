using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kmcmvc.Areas.Admin.Data;
using System.Linq.Dynamic;
using System.Data.Entity.Validation;

namespace kmcmvc.Areas.Admin.Controllers
{
    //[Authorize]
    public class userinfoesController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/userinfoes
        public ActionResult Index()
        {
            return View();
        }


        // POST: Admin/role
        [HttpPost]
        public JsonResult AjaxMethod()
        {
            using (AdminEntities entities = new AdminEntities())
            {
                List<role> roles = (from role in entities.roles
                                    select role).ToList();
                return Json(roles);
            }
        }

        // POST: Admin/userinfoes
        [HttpPost]
        public ActionResult GetList()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request.Form.GetValues("search[value]")[0];
            string sortColumnName = Request.Form.GetValues("columns[" +
            Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            string sortDirection = Request["order[0][dir]"];

            List<userinfo> userinfoe = new List<userinfo>();
            int totalrecord = userinfoe.Count;
            using (AdminEntities db = new AdminEntities())
            {
                userinfoe = (from p in db.userinfoes
                             join f in db.roles
                        on p.RoleID equals f.RoleID
                             join a in db.accountstatus
                       on p.AccountStatusID equals a.AccountStatusID
                             where (p.FullName.ToLower() != null)
                             select new
                             {
                                 Id = p.userinfoID,
                                 Username = p.Username,
                                 FullName = p.FullName,
                                 status = a.AccountStatus,
                                 Rolename = f.RoleName
                             }).ToList()
                      .Select(x => new userinfo()
                      {
                          userinfoID = x.Id,
                          Username = x.Username,
                          FullName = x.FullName,
                          status = x.status,
                          Rolename = x.Rolename
                      }).ToList<userinfo>();

               // userinfoe = db.userinfoes.Where(x => x.FullName.ToLower() != null).ToList<userinfo>();

                if (!string.IsNullOrEmpty(searchValue))
                {
                    userinfoe = userinfoe.
                        Where(x => x.Username.ToLower().Contains(searchValue.ToLower()) || x.FullName.ToLower().Contains(searchValue.ToLower()) || x.Rolename.Contains(searchValue.ToLower()) || x.status.Contains(searchValue.ToLower())).ToList<userinfo>();
                }
                int totalrowsafterfiltering = userinfoe.Count;
                // sorting
                userinfoe = userinfoe.OrderBy(sortColumnName + " " + sortDirection).ToList<userinfo>();


                // pagination
                userinfoe = userinfoe.Skip(start).Take(length).ToList<userinfo>();

                return Json(new { data = userinfoe, draw = Request["draw"], recordsTotal = totalrecord, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/userinfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var userinfolist = (from p in db.userinfoes
                            join f in db.roles
                       on p.RoleID equals f.RoleID
                            join a in db.accountstatus
                       on p.AccountStatusID equals a.AccountStatusID
                           where (p.userinfoID == id)
                           select new
                           {
                               Id = p.userinfoID,
                               Username = p.Username,
                               FullName = p.FullName,
                               Password = p.Password,
                               Mobile = p.Mobile,
                               Email = p.Email,
                               CNIC = p.CNIC,
                               Address = p.Address,
                               status = a.AccountStatus,
                               Rolename = f.RoleName
                           }).ToList()
                    .Select(x => new userinfo()
                    {
                        userinfoID = x.Id,
                        Username = x.Username,
                        FullName = x.FullName,
                        Password = x.Password,
                        Mobile = x.Mobile,
                        Email = x.Email,
                        CNIC = x.CNIC,
                        Address = x.Address,
                        status = x.status,
                        Rolename = x.Rolename
                    }).SingleOrDefault();



            //userinfo userinfo = db.userinfoes.Find(id);
            if (userinfolist == null)
            {
                return HttpNotFound();
            }
            return View(userinfolist);
        }



        // GET: Admin/userinfoes/Create
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            userinfo u = new userinfo();
            u.rolelist = db.roles.ToList();
            u.statuslist = db.accountstatus.Where(x => x.AccountStatus == "Active" || x.AccountStatus == "De-Active" || x.AccountStatus == "Suspended").ToList();
            u.status = "";
            u.Rolename = "";
            return View(u);
        }

        // POST: Admin/userinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userinfoID,Username,FullName,Password,Mobile,Email,CNIC,Address,RoleID,AccountStatusID")] userinfo userinfo)
        {
            if (!ModelState.IsValid)
            {
                db.userinfoes.Add(userinfo);
                //db.Entry(userinfo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                db.userinfoes.Add(userinfo);
                db.Entry(userinfo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        // GET: Admin/userinfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            userinfo userinfo = new userinfo();
            userinfo = db.userinfoes.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            userinfo.rolelist = db.roles.ToList();
            userinfo.statuslist = db.accountstatus.Where(x => x.AccountStatus == "Active" || x.AccountStatus == "De-Active" || x.AccountStatus == "Suspended").ToList();
            userinfo.status = "";
            userinfo.Rolename = "";
            
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // POST: Admin/userinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userinfoID,Username,FullName,Password,Mobile,Email,CNIC,Address,RoleID,AccountStatusID")] userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinfo);
        }

        // GET: Admin/userinfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userinfo userinfo = db.userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // POST: Admin/userinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userinfo userinfo = db.userinfoes.Find(id);
            db.userinfoes.Remove(userinfo);
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
