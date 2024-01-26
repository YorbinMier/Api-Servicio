using apiServicio.Models;
using apiServicio.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiServicio.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class clAlmacenController
    {
        private readonly IclAlmacenService _clAlmacenService;

        public clAlmacenController(IclAlmacenService clAlmacenService)
        {
            _clAlmacenService = clAlmacenService;
        }

        [HttpGet]
        public async Task<List<clAlmacen>> GetList()
        {
            return await _clAlmacenService.GetList();
        }

        [HttpPost("AgregaActualiza")]
        public async Task<clAlmacen> AgregaActualiza(
    int IdAlmacen,
    string NombreAlmacen,
    int IdEntidad,
    DateTime FechaRegistro,
        string EstadoRegistro,
    string t)
        {
            clAlmacen almacen = new clAlmacen
            {
                IdAlmacen = IdAlmacen,
                NombreAlmacen = NombreAlmacen,
                IdEntidad = IdEntidad,
                FechaRegistro = FechaRegistro,
                EstadoRegistro = EstadoRegistro
            };

            return await _clAlmacenService.AgregaActualiza(almacen, t);
        }


        [HttpDelete("Elimina")]
        public async Task<bool> Elimina([FromQuery] int id)
        {
            return await _clAlmacenService.Elimina(id);
        }

        [HttpGet("{id}")]
        public async Task<clAlmacen> GetById(int id)
        {
            return await _clAlmacenService.GetById(id);
        }



    }
}
