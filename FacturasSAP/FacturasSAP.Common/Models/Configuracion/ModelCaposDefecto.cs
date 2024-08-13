using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Configuracion
{
    public class ModelCaposDefecto
    {
        public bool Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public String CreadoPor { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public String ModificadoPor { get; set; }
    }
}
