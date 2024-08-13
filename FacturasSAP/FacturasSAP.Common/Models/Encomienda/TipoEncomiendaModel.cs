﻿using FacturasSAP.Common.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.Common.Models.Encomienda
{
    public class TipoEncomiendaModel:ModelCaposDefecto
    {
        public int IdTipoEncomienda { get; set; }
        public string Descripcion { get; set; }
    }
}
