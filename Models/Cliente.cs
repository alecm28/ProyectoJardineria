using System.Runtime.Caching;

namespace ProyectoJardineria.Models
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ProvinciaCliente { get; set; }
        public string CantonCliente { get; set; }
        public string DistritoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string InviernoCliente { get; set; } // Quincenal o Mensual
        public string VeranoCliente { get; set; } // Quincenal o Mensual

        private ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
        private string cacheKey = "ListaClientes";

        // Obtener lista de empleados desde la caché
        public List<Cliente> ObtenerClientes()
        {
            if (cache[cacheKey] == null)
            {
                cache[cacheKey] = new List<Cliente>();  // Si no existe, inicializamos una lista vacía
            }
            return (List<Cliente>)cache[cacheKey];
        }

        // Agregar empleado a la lista
        public void AgregarCliente(Cliente cliente)
        {
            var clientes = ObtenerClientes();
            clientes.Add(cliente);
            cache[cacheKey] = clientes;
        }

        // Editar un empleado existente
        public void EditarCliente(Cliente clienteActualizado)
        {
            var clientes = ObtenerClientes();
            var cliente = clientes.Find(e => e.IdCliente == clienteActualizado.IdCliente);

            if (cliente != null)
            {
                cliente.NombreCliente = clienteActualizado.NombreCliente;
                cliente.ProvinciaCliente = clienteActualizado.ProvinciaCliente;
                cliente.CantonCliente = clienteActualizado.CantonCliente;
                cliente.DistritoCliente = clienteActualizado.DistritoCliente;
                cliente.DireccionCliente = clienteActualizado.DireccionCliente;
                cliente.InviernoCliente = clienteActualizado.InviernoCliente;
                cliente.VeranoCliente = clienteActualizado.VeranoCliente;

                cache[cacheKey] = clientes;
            }
        }

        // Eliminar cliente
        public void EliminarCliente(string id)
        {

            var clientes = ObtenerClientes();
            var cliente = clientes.Find(e => e.IdCliente == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                cache[cacheKey] = clientes;
            }
        }
    }
}
