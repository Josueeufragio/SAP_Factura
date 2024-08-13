using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Encomienda
{
    public class PagoEncomiendaModel: ModelCaposDefecto
    {
        public int Id { get; set; }
        public string CodigoSAP { get; set; }
        public int IdRetencionImpuesto { get; set; }
        public string RetencionImpuesto { get; set; }
        public int IdTipoExoneradoSAP  { get; set; }
        public string TipoExoneracion { get; set; }
        public string FacturaSAP { get; set; }
        public bool Dolar { get; set; }
        public DateTime Fecha { get; set; }
        public bool EnvidoSap { get; set; }
        public List<PaisModel> paisList { get; set; }
        public List<PagosEncomiendaDetalleModel> PagosEncomiendaDetalle { get; set; }
    }
}
