using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoJardineria.Models;

namespace ProyectoJardineria.Controllers
{
    public class MaquinariaController : Controller
    {
        public static IList<Maquinaria> maquinarias = new List<Maquinaria>();
        private Maquinaria maquinariaService = new Maquinaria();
        // GET: MaquinariaController
        public ActionResult Index()
        {
            var maquinarias = maquinariaService.ObtenerMaquinaria();
            return View(maquinarias);
        }

        // GET: MaquinariaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MaquinariaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaquinariaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Maquinaria maquinaria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    maquinariaService.AgregarMaquinaria(maquinaria);
                    return RedirectToAction("Index");
                }

                return View(maquinaria);
            }
            catch
            {
                return View();
            }
        }

        // GET: MaquinariaController/Edit/5
        public ActionResult Edit(int id)
        {
            var maquinarias = maquinariaService.ObtenerMaquinaria();
            var maquinaria = maquinarias.Find(e => e.IdInventario == id);

            return View(maquinaria);
        }

        // POST: MaquinariaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Maquinaria maquinaria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    maquinariaService.EditarMaquinaria(maquinaria);
                    return RedirectToAction("Index");
                }

                return View(maquinaria);


            }
            catch
            {
                return View();
            }
        }

        // GET: MaquinariaController/Delete/5
        public ActionResult Delete(int id)
        {
            var maquinarias = maquinariaService.ObtenerMaquinaria();
            var maquinaria = maquinarias.Find(e => e.IdInventario == id);

            if (maquinaria == null)
            {
                return NotFound();
            }

            return View(maquinaria);
        }

        // POST: MaquinariaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Maquinaria maquinaria)
        {
            try
            {
                if (maquinaria.IdInventario > 0)
                {
                    // Usar el servicio para eliminar el empleado por su cédula
                    maquinariaService.EliminarMaquinaria(maquinaria.IdInventario);

                    // Redirigir al índice después de eliminar
                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejar el caso en que la cédula sea nula o vacía
                    ModelState.AddModelError("", "No se puede eliminar: la cédula no es válida.");
                    return View(maquinaria);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
