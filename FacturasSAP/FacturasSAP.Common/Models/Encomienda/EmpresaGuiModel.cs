using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Encomienda
{
    public class EmpresaGuiModel:ModelCaposDefecto
    {
        public int IdEmpresaGuia { get; set; }
        public string Descripcion { get; set; }
        public string CodigoSap { get; set; }
        public string ExpresionRegular{ get; set; }
    }
}
