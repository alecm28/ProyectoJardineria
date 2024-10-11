using Castle.DynamicProxy.Generators;
using System.Runtime.Caching;

namespace ProyectoJardineria.Models
{
    public class Empleado
    {
        public string CedulaEmpleado { get; set; }
        public DateTime NacimientoEmpleado { get; set; }
        public string LateralidadEmpleado { get; set; } // Diestro o Zurdo
        public DateTime IngresoEmpleado { get; set; }
        public int SalarioEmpleado { get; set; } //por hora

        private ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
        private string cacheKey = "ListaEmpleados";

        // Obtener lista de empleados desde la caché
        public List<Empleado> ObtenerEmpleados()
        {
            if (cache[cacheKey] == null)
            {
                cache[cacheKey] = new List<Empleado>();  // Si no existe, inicializamos una lista vacía
            }
            return (List<Empleado>)cache[cacheKey];
        }

        // Agregar empleado a la lista
        public void AgregarEmpleado(Empleado empleado)
        {
            var empleados = ObtenerEmpleados();
            empleados.Add(empleado);
            cache[cacheKey] = empleados;
        }

        // Editar un empleado existente
        public void EditarEmpleado(Empleado empleadoActualizado)
        {
            var empleados = ObtenerEmpleados();
            var empleado = empleados.Find(e => e.CedulaEmpleado == empleadoActualizado.CedulaEmpleado);

            if (empleado != null)
            {
                empleado.NacimientoEmpleado = empleadoActualizado.NacimientoEmpleado;
                empleado.LateralidadEmpleado = empleadoActualizado.LateralidadEmpleado;
                empleado.IngresoEmpleado = empleadoActualizado.IngresoEmpleado;
                empleado.SalarioEmpleado = empleadoActualizado.SalarioEmpleado;

                cache[cacheKey] = empleados;
            }
        }

        // Eliminar empleado
        public void EliminarEmpleado(string cedula)
        {

            var empleados = ObtenerEmpleados();
            var empleado = empleados.Find(e => e.CedulaEmpleado == cedula);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                cache[cacheKey] = empleados;
            }
        }
    }
}
