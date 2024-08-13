using FacturasSAP.Common.Models.Configuracion;
using FacturasSAP.Common.Models.Encomienda;
using FacturasSAP.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.BusinessLogic.Services
{
    public class PagoEncomiendaServices
    {
        private readonly PagoFacturaRepository _pagoFacturaRepository;
        public PagoEncomiendaServices(PagoFacturaRepository pagoFacturaRepository)
        {
            _pagoFacturaRepository = pagoFacturaRepository;
        }


        public async Task<ModelResult<PagoEncomiendaModel>> ListaPagos()
        {
           return await _pagoFacturaRepository.listAsync();
        }
    }
}
