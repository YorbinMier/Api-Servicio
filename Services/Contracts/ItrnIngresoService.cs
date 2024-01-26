using apiServicio.Models;

namespace apiServicio.Services.Contracts
{
    public interface ItrnIngresoService
    {
        Task<List<trnIngreso>> GetList();
        Task<trnIngreso> AgregaActualiza(trnIngreso l, string t);
        Task Eliminar(int idIngreso);
        Task<trnIngreso> Buscar(int idIngreso);
    }
}
