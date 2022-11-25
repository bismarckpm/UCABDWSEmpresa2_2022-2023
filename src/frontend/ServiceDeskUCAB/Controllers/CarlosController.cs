using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDeskUCAB.Controllers
{
    public class CarlosController : Controller
    {
        // GET: CarlosController
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Julio()
        {
            return View();
        }



        // GET: CarlosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarlosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarlosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarlosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarlosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarlosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarlosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
