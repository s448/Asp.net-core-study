using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using training.Models;

namespace training.Controllers
{
    public class RoomController : Controller
    {
        TrainingDbContext Db = new TrainingDbContext();
        public ActionResult Index()
        {
            List<Room> rooms = new List<Room>();

            rooms = (from r in Db.rooms select r).ToList();
            return View(rooms);
        }

        public ActionResult GetRoomDetails(int id)
        {
            Room room = new Room();

            room = (from r in Db.rooms where r.roomId == id select r).FirstOrDefault();

            return View(room);
        }

        public ActionResult AddRoom()
        {
            Room room = new Room();
            room.roomName = "Name 1";
            room.roomId = 1;
            room.isAvailible = true;
            room.roomSize = 53;
            room.location = "location";

            Db.rooms.Add(room);

            Db.SaveChanges();

            return View("RoomsView");
        }

        public ActionResult DeleteRoom(int id)
        {
            Room room = new Room();
            room = (from r in Db.rooms where r.roomId == id select r).FirstOrDefault();

            Db.rooms.Remove(room);
            Db.SaveChanges();

            return View("RoomsView");
        }

        public ActionResult UpdateRoom(int id)
        {
            Room room = new Room();
            room = (from r in Db.rooms where r.roomId == id select r).FirstOrDefault();

            room.roomName = "update";
            room.isAvailible = false;
            Db.SaveChanges();

            return View("RoomsView");
        }
    }
}