using apiServicio.Business.Contracts;
using apiServicio.Models;
using apiServicio.Services.Contracts;

namespace apiServicio.Services.Clases
{
    public class clAlmacenService : IclAlmacenService
    {
        private readonly IclAlmacenRepository _clAlmacenRepository;

        public clAlmacenService(IclAlmacenRepository clAlmacenRepository)
        {
            _clAlmacenRepository = clAlmacenRepository ??
             throw new ArgumentNullException(nameof(clAlmacenRepository));
        }

        public async Task<List<clAlmacen>> GetList()
        {
            return await _clAlmacenRepository.GetList();
        }

        public async Task<clAlmacen> AgregaActualiza(clAlmacen almacen, string tipo)
        {
            if (almacen == null)
                throw new ArgumentNullException(nameof(almacen));

            return await _clAlmacenRepository.AgregaActualiza(almacen, tipo);
        }

        public async Task<bool> Elimina(int id)
        {
            return await _clAlmacenRepository.Elimina(id);
        }


        public Task<clAlmacen> GetById(int id)
        {
            return _clAlmacenRepository.GetById(id);
        }


    }
}
