using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.DataAccess.Repositories.Interface
{
    public interface IPagoFecturaEncomiendaRepository<M>
    {
        public Task<ModelResult<M>> listAsync();
        public Task<ModelResult<M>> whereAsync(int id);
        public Task<ModelResult<bool>> guardarAsync(M model);

    }
}
