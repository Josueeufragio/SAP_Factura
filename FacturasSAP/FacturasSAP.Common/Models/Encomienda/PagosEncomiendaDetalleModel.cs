using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Encomienda
{
    public class PagosEncomiendaDetalleModel:ModelCaposDefecto
    {

        public int IdPagoEncomiendaDetalle { get; set; }
        public int IdPagoEncomienda { get; set; }
        public int IdTipoEncomienda { get; set; }
        public int IdPais { get; set; }
        public string Lugar { get; set; }
        public string Traking { get; set; }
        public decimal PrecioFlete { get; set; }
        public decimal DescuentoOtorgado{ get; set; }
        public decimal RecargoPorCombustible { get; set; }

    }
}
