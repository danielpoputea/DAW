using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SodasController : Controller
    {
        public static List<Models.Soda> sodas = new List<Models.Soda>()
    {
        new Models.Soda() {Id=Guid.NewGuid(), Brand = "Fanta", Quantity=5, Price = 2},
        new Models.Soda() {Id=Guid.NewGuid(), Brand = "cola", Quantity=52, Price = 1},
    };
    
        // GET: Sodas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sodas/Details/5
        public ActionResult Details(Guid id)
        {
            return View(sodas.FirstOrDefault(soda => soda.Id.Equals(id)));
        }

        // GET: Sodas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sodas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                Models.Soda soda = new Models.Soda();
                soda.Id = Guid.NewGuid();

                soda.Brand = collection["Brand"];
                soda.Quantity = int.Parse(collection["Quantity"]);
                soda.Price = int.Parse(collection["Price"]);
              
                sodas.Add(soda);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sodas/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Sodas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                Models.Soda soda = sodas.FirstOrDefault(x => x.Id.Equals(id));

                soda.Brand = collection["Brand"];
                soda.Quantity = int.Parse(collection["Quantity"]);
                soda.Price = int.Parse(collection["Price"]);
                
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: Sodas/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(sodas.FirstOrDefault(soda => soda.Id.Equals(id)));
        }

        // POST: Sodas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                sodas.Remove(sodas.FirstOrDefault(soda => soda.Id.Equals(id)));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(sodas.FirstOrDefault(soda => soda.Id.Equals(id)));
            }
        }
    }
}