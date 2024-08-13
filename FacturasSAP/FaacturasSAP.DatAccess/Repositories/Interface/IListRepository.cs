using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.DatAccess.Repositories.Interface
{
    public interface IListRepository<T>
    {
        public Task<ModelResult<T>> listAsync();
    }
}
