using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DogsController : Controller
    {
        public static List<Models.Dog> dogs = new List<Models.Dog>()
    {
        new Models.Dog() {Id=Guid.NewGuid(), Age = 3, Weight=10, Name = "Oxy", Breed = "Bichon"},
        new Models.Dog() {Id=Guid.NewGuid(), Age = 1, Weight=10, Name = "Bella", Breed = "Caucasian Shepherd"},
        new Models.Dog() {Id=Guid.NewGuid(), Age = 9, Weight=50, Name = "Ursu", Breed = "Caucasian Shepherd"},
    };

        // GET: Dogs
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dogs/Details/5
        public ActionResult Details(Guid id)
        {
            return View(dogs.FirstOrDefault(dog => dog.Id.Equals(id)));
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.Dog dog = new Models.Dog();
                dog.Id = Guid.NewGuid();

                dog.Age = int.Parse(collection["Age"]);
                dog.Weight = int.Parse(collection["Weight"]);
                dog.Name = collection["Name"];
                dog.Breed = collection["Breed"];

                dogs.Add(dog);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dogs/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(dogs.FirstOrDefault(dog => dog.Id.Equals(id)));
        }

        // POST: Dogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                Models.Dog dog = dogs.FirstOrDefault(x => x.Id.Equals(id));

                dog.Age = int.Parse(collection["Age"]);
                dog.Weight = int.Parse(collection["Weight"]);
                dog.Name = collection["Name"];
                dog.Breed = collection["Breed"];

                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dogs/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(dogs.FirstOrDefault(dog => dog.Id.Equals(id)));
        }

        // POST: Dogs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                dogs.Remove(dogs.FirstOrDefault(dog => dog.Id.Equals(id)));
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dogs.FirstOrDefault(dog => dog.Id.Equals(id)));
            }
        }
    }
}