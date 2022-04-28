using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelSite.BLL;
using OtelSite.Models;

namespace OtelSite.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        RoomRepository _roomrp = new RoomRepository();
        
        // GET: Admin/Base
        public BaseController()
        {
            ViewData["Rooms"] = _roomrp.Listele();

   
        }
    }
}

