using apiServicio.Models;

namespace apiServicio.Business.Contracts
{
    public interface ItrnIngresoRepository
    {
        Task<List<trnIngreso>> GetList();
        Task<trnIngreso> AgregaActualiza(trnIngreso l, string t);
        Task Eliminar(int idIngreso);
        Task<trnIngreso> Buscar(int idIngreso);
    }
}
