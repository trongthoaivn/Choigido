using Choigido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Choigido.Controllers
{
    public class GameRoomController : Controller
    {
        // GET: GameRoom
        public ActionResult GameRoom(string Id)
        {
            var room = new DAOController().getRoomInf(Id);
            if(room != null)
            {
                return View(room);
            }
            else
            {
                return RedirectToAction("Trangchu", "Trangchu");
            }
        }
    }
}