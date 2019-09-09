using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RoomsController : Controller
    {
        public static List<Models.Room> rooms = new List<Models.Room>()
    {
        new Models.Room() {Id=Guid.NewGuid(), Length = 3, Width=5, Color = "Blue", Style = "Classic"},
        new Models.Room() {Id=Guid.NewGuid(), Length = 3, Width=4, Color = "White", Style = "Classic"},
    };
        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rooms/Details/5
        public ActionResult Details(Guid id)
        {           
                return View(rooms.FirstOrDefault(room => room.Id.Equals(id)));
           
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.Room room = new Models.Room();
                room.Id = Guid.NewGuid();

                room.Color = collection["Color"];
                room.Length = int.Parse(collection["Length"]);
                room.Width = int.Parse(collection["Width"]);
                room.Style = collection["Style"];
            
                rooms.Add(room);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(rooms.FirstOrDefault(room => room.Id.Equals(id)));
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                Models.Room room = rooms.FirstOrDefault(x => x.Id.Equals(id));
               
                room.Color = collection["Color"];
                room.Length = int.Parse(collection["Length"]);
                room.Width = int.Parse(collection["Width"]);
                room.Style = collection["Style"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(rooms.FirstOrDefault(room => room.Id.Equals(id)));
        }

        // POST: Rooms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                rooms.Remove(rooms.FirstOrDefault(room => room.Id.Equals(id)));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(rooms.FirstOrDefault(room => room.Id.Equals(id)));
            }
        }
    }
}