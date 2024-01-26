using apiServicio.Models;

namespace apiServicio.Services.Contracts
{
    public interface IclAlmacenService
    {
        Task<List<clAlmacen>> GetList();
        Task<clAlmacen> AgregaActualiza(clAlmacen almacen, string tipo);
        Task<bool> Elimina(int id);
        Task<clAlmacen> GetById(int id);

    }
}
