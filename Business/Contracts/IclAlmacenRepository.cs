using apiServicio.Models;

namespace apiServicio.Business.Contracts
{
    public interface IclAlmacenRepository
    {
        Task<List<clAlmacen>> GetList();
        Task<clAlmacen> AgregaActualiza(clAlmacen al, string tipo);
        Task<bool> Elimina(int id);
        Task<clAlmacen> GetById(int idAlmacen);

    }
}
