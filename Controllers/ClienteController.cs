using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoJardineria.Models;

namespace ProyectoJardineria.Controllers
{
    public class ClienteController : Controller
    {
        public static IList<Cliente> clientes = new List<Cliente>();
        private Cliente clienteService = new Cliente();
        // GET: ClienteController
        public ActionResult Index()
        {
            var clientes = clienteService.ObtenerClientes();
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteService.AgregarCliente(cliente);
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(string id)
        {
            var clientes = clienteService.ObtenerClientes();
            var cliente = clientes.Find(e => e.IdCliente == id);

            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteService.EditarCliente (cliente);
                    return RedirectToAction("Index");
                }

                return View(cliente);


            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(string id)
        {
            var clientes = clienteService.ObtenerClientes();
            var cliente = clientes.Find(e => e.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cliente cliente)
        {
            try
            {
                if (!string.IsNullOrEmpty(cliente.IdCliente))
                {
                    // Usar el servicio para eliminar el empleado por su cédula
                    clienteService.EliminarCliente(cliente.IdCliente);

                    // Redirigir al índice después de eliminar
                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejar el caso en que la cédula sea nula o vacía
                    ModelState.AddModelError("", "No se puede eliminar: la cédula no es válida.");
                    return View(cliente);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
