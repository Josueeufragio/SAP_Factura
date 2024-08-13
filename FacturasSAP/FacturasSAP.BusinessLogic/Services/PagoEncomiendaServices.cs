using FacturasSAP.Common.Models.Configuracion;
using FacturasSAP.Common.Models.Encomienda;
using FacturasSAP.DataAccess.Repositories;
using FacturasSAP.DatAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.BusinessLogic.Services
{
    public class PagoEncomiendaServices
    {
        private readonly PagoFacturaEncomiendaRepository _pagoFacturaRepository;
        private readonly TipoExoneracionRepository _tipoExoneracionRepository;
        private readonly TipoRetencionRepository _tipoRetencionRepository;
        private readonly PaisRepository _paisRepository;

        public PagoEncomiendaServices(
            PagoFacturaEncomiendaRepository pagoFacturaRepository,
            TipoExoneracionRepository tipoExoneracionRepository,
            TipoRetencionRepository tipoRetencionRepository,
            PaisRepository paisRepository
        )
        {
            _pagoFacturaRepository = pagoFacturaRepository;
            _tipoExoneracionRepository = tipoExoneracionRepository;
            _tipoRetencionRepository = tipoRetencionRepository;
            _paisRepository = paisRepository;
        }


        public async Task<ModelResult<PagoEncomiendaModel>> ListaPagos()
        {
           return await _pagoFacturaRepository.listAsync();
        }

        public async Task<ModelResult<bool>> Guardar(PagoEncomiendaModel model)
        {
            return await _pagoFacturaRepository.guardarAsync(model);
        }

        public async Task<ModelResult<TipoExoneracionModel>> listAsyncTipoExoneracion()
        {
            return await _tipoExoneracionRepository.listAsync();
        }

        public async Task<ModelResult<TipoRetencionModel>> ListAsyncTipoRetencion()
        {
            return await _tipoRetencionRepository.listAsync();
        }
        public async Task<ModelResult<PaisModel>> ListAsyncPais()
        {
            return await _paisRepository.listAsync();
        }
    }
}
