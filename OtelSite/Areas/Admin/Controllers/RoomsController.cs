using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OtelSite.Models;

namespace OtelSite.Areas.Admin.Controllers
{
    public class RoomsController : Controller
    {
        private OtelSiteEntities db = new OtelSiteEntities();

        // GET: Admin/Rooms
        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.RoomsType);
            return View(rooms.ToList().OrderBy(x=>x.Number));
        }

        // GET: Admin/Rooms/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Admin/Rooms/Create
        public ActionResult Create()
        {
            ViewBag.RoomTypeId = new SelectList(db.RoomsTypes, "Id", "Room");
            return View();
        }

        // POST: Admin/Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,RoomTypeId,Status")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.Id = Guid.NewGuid();
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomTypeId = new SelectList(db.RoomsTypes, "Id", "Room", room.RoomTypeId);
            return View(room);
        }

        // GET: Admin/Rooms/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomTypeId = new SelectList(db.RoomsTypes, "Id", "Room", room.RoomTypeId);
            return View(room);
        }

        // POST: Admin/Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,RoomTypeId,Status")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomTypeId = new SelectList(db.RoomsTypes, "Id", "Room", room.RoomTypeId);
            return View(room);
        }

        // GET: Admin/Rooms/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
