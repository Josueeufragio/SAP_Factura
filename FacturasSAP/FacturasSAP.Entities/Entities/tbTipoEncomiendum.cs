﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FacturasSAP.Entities.Entities;

public partial class tbTipoEncomiendum
{
    public int IdTipoEncomienda { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<tbPagoEncomiendaDetalle> tbPagoEncomiendaDetalles { get; set; } = new List<tbPagoEncomiendaDetalle>();
}