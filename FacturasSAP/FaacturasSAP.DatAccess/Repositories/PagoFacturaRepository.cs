using FacturasSAP.Common.Models.Configuracion;
using FacturasSAP.Common.Models.Encomienda;
using FacturasSAP.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.DataAccess.Repositories
{
    public class PagoFacturaRepository : IPagoFecturaRepository<PagoEncomiendaModel>
    {
        public async Task<ModelResult<PagoEncomiendaModel>> listAsync()
        {
            try
            
            {
                using var db = new FacturaSAPContext();
                ModelResult<PagoEncomiendaModel> resul = new ModelResult<PagoEncomiendaModel>();
                var pagoEnc = await db.tbPagoEncomienda.ToListAsync();

                resul.Success = pagoEnc.Count > 0;
                resul.Message = resul.Success ? "Datos Octenidos Correctamente": "No tiene Datos";
                resul.Data = pagoEnc.Select(a => new PagoEncomiendaModel
                {
                    Id = a.IdPagoEncomienda,
                    Factura = a.Factura
                }).ToList();
                return resul;
            }
            catch (Exception ex)
            {
                return new ModelResult<PagoEncomiendaModel> { Message = ex.Message ,Success = false};
            }
        }

        public Task<ModelResult<PagoEncomiendaModel>> whereAsync()
        {
            throw new NotImplementedException();
        }
    }
}
