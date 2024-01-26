using apiServicio.Business.Contracts;
using apiServicio.Models;
using apiServicio.Services.Contracts;

namespace apiServicio.Services.Clases
{
    public class trnIngresoService : ItrnIngresoService
    {
        private readonly ItrnIngresoRepository _ItrnIngresoRepository;
        public trnIngresoService(ItrnIngresoRepository temp)
        {
            _ItrnIngresoRepository = temp;
        }

        public Task<List<trnIngreso>> GetList()
        {
            return _ItrnIngresoRepository.GetList();
        }
        public Task<trnIngreso> AgregaActualiza(trnIngreso l, string t)
        {
            return _ItrnIngresoRepository.AgregaActualiza(l, t);
        }

        public Task Eliminar(int idIngreso)
        {
            return _ItrnIngresoRepository.Eliminar(idIngreso);
        }

        public Task<trnIngreso> Buscar(int idIngreso)
        {
            return _ItrnIngresoRepository.Buscar(idIngreso);
        }
    }
}
