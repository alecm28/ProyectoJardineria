using Castle.DynamicProxy.Generators;
using System.Runtime.Caching;

namespace ProyectoJardineria.Models
{
    public class Maquinaria
    {
        public int IdInventario { get; set; }
        public string Descripcion { get; set; }
        public string TipoMaquinaria { get; set; } // Ej: shindaiwa, motosierra, etc.
        public int HorasUsoActuales { get; set; }
        public int HorasUsoMaxDia { get; set; }
        public int HorasUsoMantenimiento { get; set; }


        private ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;
        private string cacheKey = "ListaMaquinaria";
        public List<Maquinaria> ObtenerMaquinaria()
        {
            if (cache[cacheKey] == null)
            {
                cache[cacheKey] = new List<Maquinaria>();  // Si no existe, inicializamos una lista vacía
            }
            return (List<Maquinaria>)cache[cacheKey];
        }

        public void AgregarMaquinaria(Maquinaria maquinaria)
        {
            var listaMaquinaria = ObtenerMaquinaria();
            maquinaria.IdInventario = listaMaquinaria.Count + 1;  // Generar un Id incremental
            listaMaquinaria.Add(maquinaria);
            cache[cacheKey] = listaMaquinaria;
        }

        public void EditarMaquinaria(Maquinaria maquinariaActualizada)
        {
            var listaMaquinaria = ObtenerMaquinaria();
            var maquinaria = listaMaquinaria.FirstOrDefault(m => m.IdInventario == maquinariaActualizada.IdInventario);

            if (maquinaria != null)
            {
                maquinaria.Descripcion = maquinariaActualizada.Descripcion;
                maquinaria.TipoMaquinaria = maquinariaActualizada.TipoMaquinaria;
                maquinaria.HorasUsoActuales = maquinariaActualizada.HorasUsoActuales;
                maquinaria.HorasUsoMaxDia = maquinariaActualizada.HorasUsoMaxDia;
                maquinaria.HorasUsoMantenimiento = maquinariaActualizada.HorasUsoMantenimiento;

                cache[cacheKey] = listaMaquinaria;
            }
        }
        // Eliminar maquinaria del inventario
        public void EliminarMaquinaria(int id)
        {
            var listaMaquinaria = ObtenerMaquinaria();
            var maquinaria = listaMaquinaria.FirstOrDefault(m => m.IdInventario == id);
            if (maquinaria != null)
            {
                listaMaquinaria.Remove(maquinaria);
                cache[cacheKey] = listaMaquinaria;
            }
        }

        // Buscar maquinaria por ID
        public Maquinaria BuscarMaquinariaPorId(int id)
        {
            var listaMaquinaria = ObtenerMaquinaria();
            return listaMaquinaria.FirstOrDefault(m => m.IdInventario == id);
        }


    }
}
