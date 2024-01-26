using System.ComponentModel.DataAnnotations;

namespace apiServicio.Models
{
    public class trnIngreso
    {
        public int IdIngreso { get; set; }
        public string NumeroIngreso { get; set; }
        public DateTime FechaReal { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string ComprobantePago { get; set; }
        public string NumeroFactura { get; set; }
        public string NumeroPreventivo { get; set; }
        public string Observacion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public int IdGrupoArticulo { get; set; }
        public int IdProveedor { get; set; }
        public int IdGestion { get; set; }
        public int IdEntidad { get; set; }
        public int IdUsuarioIngreso { get; set; }
        public int IdAlmacen { get; set; }
        public int IdEstadoIngreso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoRegistro { get; set; }
        public int IdTipoDocumentoEntrega { get; set; }

    }
}
