using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.DataAccess.Repositories.Interface
{
    public interface IPagoFecturaRepository<M>
    {
        public Task<ModelResult<M>> listAsync();

        public Task<ModelResult<M>> whereAsync();

    }
}
