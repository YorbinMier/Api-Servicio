namespace apiServicio.Models
{
    public class clAlmacen
    {
        public int IdAlmacen { get; set; }
        public string NombreAlmacen { get; set; }
        public int IdEntidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoRegistro { get; set; }
    }
}
