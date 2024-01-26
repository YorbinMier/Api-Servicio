using apiServicio.Models;
using apiServicio.Services.Clases;
using apiServicio.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace apiServicio.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class trnIngresoController
    {
        private readonly ItrnIngresoService _ItrnIngresoService;

        public trnIngresoController(ItrnIngresoService temp)
        {
            this._ItrnIngresoService = temp;
        }
        [HttpGet]
        public async Task<List<trnIngreso>> GetList()
        {
            return await _ItrnIngresoService.GetList();
        }
        [HttpPost("AgregaActualiza")]
        public async Task<trnIngreso> AgregaActualiza(
    int IdIngreso, string NumeroIngreso, DateTime FechaReal, DateTime FechaIngreso,
    string ComprobantePago, string NumeroFactura, string NumeroPreventivo,
    string Observacion, decimal SubTotal, decimal Total, decimal Descuento,
    int IdGrupoArticulo, int IdProveedor, int IdGestion, int IdEntidad,
    int IdUsuarioIngreso, int IdAlmacen, int IdEstadoIngreso, DateTime FechaRegistro,
    string EstadoRegistro, int IdTipoDocumentoEntrega, string t)
        {
            trnIngreso l = new trnIngreso();

            l.IdIngreso = IdIngreso;
            l.NumeroIngreso = NumeroIngreso;
            l.FechaReal = FechaReal;
            l.FechaIngreso = FechaIngreso;
            l.ComprobantePago = ComprobantePago;
            l.NumeroFactura = NumeroFactura;
            l.NumeroPreventivo = NumeroPreventivo;
            l.Observacion = Observacion;
            l.SubTotal = SubTotal;
            l.Total = Total;
            l.Descuento = Descuento;
            l.IdGrupoArticulo = IdGrupoArticulo;
            l.IdProveedor = IdProveedor;
            l.IdGestion = IdGestion;
            l.IdEntidad = IdEntidad;
            l.IdUsuarioIngreso = IdUsuarioIngreso;
            l.IdAlmacen = IdAlmacen;
            l.IdEstadoIngreso = IdEstadoIngreso;
            l.FechaRegistro = FechaRegistro;
            l.EstadoRegistro = EstadoRegistro;
            l.IdTipoDocumentoEntrega = IdTipoDocumentoEntrega;

            return await _ItrnIngresoService.AgregaActualiza(l, t);
        }
        [HttpDelete("{idIngreso}")]
        public async Task Eliminar(int idIngreso)
        {
            await _ItrnIngresoService.Eliminar(idIngreso);
        }

        [HttpGet("{idIngreso}")]
        public async Task<trnIngreso> Buscar(int idIngreso)
        {
            return await _ItrnIngresoService.Buscar(idIngreso);
        }

    }
}
