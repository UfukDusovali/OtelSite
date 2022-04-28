using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelSite.BLL;
using OtelSite.Models;

namespace OtelSite.Areas.Admin.Controllers
{

    public class RezarvasyonController : Controller
    {
        RervRoomDateRepository _RervRoomDateRepository = new RervRoomDateRepository();

        RoomRepository _RoomRepository = new RoomRepository();


        // GET: Admin/Rezarvasyon
        public ActionResult Index()
        {

            return View();

        }
        public JsonResult _Control(DateTime bas)
        {
            List<Room> RoomList = new List<Room>();
            List<Room> RoomList2 = new List<Room>();

            if (_RervRoomDateRepository.Listele().Any(x => x.Checkin == bas))
            {
                foreach (var item in _RervRoomDateRepository.Listele())
                {
                    RoomList = _RervRoomDateRepository.Listele().Where(x => x.Checkin == bas).Select(x => new Room
                    {
                        Id = x.RoomId,
                        Number = x.Room.Number
                    }).ToList();
                }

            }
            else if (!_RervRoomDateRepository.Listele().Any(x => x.Checkin == bas))
            {
                foreach (var item in _RervRoomDateRepository.Listele())
                {
                    RoomList = _RervRoomDateRepository.Listele().Where(x => x.Checkin == bas).Select(x => new Room { Id = x.RoomId, Number = x.Room.Number }).ToList();
                }

            }


            return Json(RoomList, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Rezarvasyon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Rezarvasyon/Create
        public ActionResult Create(string id = null)
        {
            if (id != null)
            {
                Guid a = Guid.Parse(id);
                Room room = _RoomRepository.IdyeGore(a);
                return View(room);
            }
            else
            {
                return View();
            }

        }

        // POST: Admin/Rezarvasyon/Create
        [HttpPost]
        public ActionResult Create(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Rezarvasyon/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Admin/Rezarvasyon/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Rezarvasyon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Rezarvasyon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
