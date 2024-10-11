namespace ProyectoJardineria.Models
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaEjecutado { get; set; }
        public DateTime FechaAgendado { get; set; }
        public float Propiedad { get; set; } //cantidad de M2
        public float CercaViva { get; set; } //cantidad de M2
        public string Zacate { get; set; } // San Agustín, Toro, etc.
        public bool ProductoAplicado { get; set; }
        public string Producto { get; set; }
        public int CostoChapia { get; set; } //M2
        public int CostoProducto { get; set; } //M2
        public string Estado { get; set; } // En proceso, Facturado, etc.
    }
}
