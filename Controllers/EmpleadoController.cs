using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoJardineria.Models;

namespace ProyectoJardineria.Controllers
{
    public class EmpleadoController : Controller
    {
        public static IList<Empleado> empleados = new List<Empleado>();
        private Empleado empleadoService = new Empleado();

        // GET: EmpleadoController
        public ActionResult Index()
        {
            var empleados = empleadoService.ObtenerEmpleados();
            return View(empleados);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleadoService.AgregarEmpleado(empleado);
                    return RedirectToAction("Index");
                }

                return View(empleado);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(string id)
        {
            var empleados = empleadoService.ObtenerEmpleados();
            var empleado = empleados.Find(e => e.CedulaEmpleado == id);

            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleadoService.EditarEmpleado(empleado);
                    return RedirectToAction("Index");
                }

                return View(empleado);


            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(string id)
        {
            var empleados = empleadoService.ObtenerEmpleados();
            var empleado = empleados.Find(e => e.CedulaEmpleado == id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Empleado empleado)
        {
            try
            {
                if (!string.IsNullOrEmpty(empleado.CedulaEmpleado))
                {
                    // Usar el servicio para eliminar el empleado por su cédula
                    empleadoService.EliminarEmpleado(empleado.CedulaEmpleado);

                    // Redirigir al índice después de eliminar
                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejar el caso en que la cédula sea nula o vacía
                    ModelState.AddModelError("", "No se puede eliminar: la cédula no es válida.");
                    return View(empleado);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
