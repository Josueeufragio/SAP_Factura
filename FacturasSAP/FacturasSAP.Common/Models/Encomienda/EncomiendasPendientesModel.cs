using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Encomienda
{
    public class EncomiendasPendientesModel
    {
        public string Traking { get; set; }
        public int IdTipoEncomienda { get; set; }
        public string Descripcion { get; set; }
        public string Destino { get; set; }
        public int IdPais { get; set; }
    }
}
