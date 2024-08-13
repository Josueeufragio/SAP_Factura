using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Configuracion
{
    public class ModelResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
        public T Value { get; set; }
    }

}
