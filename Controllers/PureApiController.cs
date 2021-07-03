using Choigido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Choigido.Controllers
{
    public class PureApiController : ApiController
    {
        [HttpGet]
        [Route("api/day")]
        public IHttpActionResult day()
        {
            return Json(new
            {
                message = "ok"
            });
        }

        [HttpGet]
        [Route("api/CreateRoom")]
        public IHttpActionResult createRoom()
        {
            string day = DateTime.Now.ToString("dd");
            string min = DateTime.Now.ToString("mm");
            string sec = DateTime.Now.ToString("ss");
            string MaPhong = "Room" + day + "" + min + "" + sec;
            day = DateTime.Now.ToString("dd");
            min = DateTime.Now.ToString("mm");
            sec = DateTime.Now.ToString("ss");
            string MaNguoiChoi = "User" + sec + "" + day + "" + min;

            //Lưu vào database
            tblChessGame room = new tblChessGame();
            room.GameID = MaPhong;
            room.PlayerBlackID = MaNguoiChoi;

            if (new DAOController().createRoom(room)) 
            {
                //return mã phòng
                return Json(new
                {
                    RoomID = MaPhong
                });
            }
            else
            {
                return Json(new
                {
                    RoomID = "Lỗi"
                });
            }
        }
    }
}
