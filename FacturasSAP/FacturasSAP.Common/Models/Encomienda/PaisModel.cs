using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Encomienda
{
    public class PaisModel:ModelCaposDefecto
    {
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public string codigo { get; set; }
    }
}
