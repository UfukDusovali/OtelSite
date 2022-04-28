using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OtelSite.Models;
using System.Security.Cryptography;
using System.Text;

namespace OtelSite.Areas.Admin.Controllers
{
    public class EmployessesController : Controller
    {
        private OtelSiteEntities db = new OtelSiteEntities();

        // GET: Admin/Employesses
        public ActionResult Index()
        {
            return View(db.Employesses.ToList());
        }

        // GET: Admin/Employesses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employess employess = db.Employesses.Find(id);
            if (employess == null)
            {
                return HttpNotFound();
            }
            return View(employess);
        }

        // GET: Admin/Employesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Mail,Password,Position")] Employess employess)
        {
            if (ModelState.IsValid)
            {
                employess.Id = Guid.NewGuid();
                employess.Password = (string)MD5Sifrele(employess.Password);
                db.Employesses.Add(employess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employess);
        }
        private string MD5Sifrele(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(password); btr = md5.ComputeHash(btr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        // GET: Admin/Employesses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employess employess = db.Employesses.Find(id);
            if (employess == null)
            {
                return HttpNotFound();
            }
            return View(employess);
        }

        // POST: Admin/Employesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Mail,Password,Position")] Employess employess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employess);
        }

        // GET: Admin/Employesses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employess employess = db.Employesses.Find(id);
            if (employess == null)
            {
                return HttpNotFound();
            }
            return View(employess);
        }

        // POST: Admin/Employesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Employess employess = db.Employesses.Find(id);
            db.Employesses.Remove(employess);
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
