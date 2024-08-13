using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Encomienda
{
    public class TipoRetencionModel:ModelCaposDefecto
    {
        public int IdRetencionImpuestos { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Tasa { get; set; }
        
    }
}
