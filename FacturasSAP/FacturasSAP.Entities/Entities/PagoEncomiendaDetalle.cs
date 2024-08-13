﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FacturasSAP.Entities.Entities;

public partial class PagoEncomiendaDetalle
{
    public int IdPagoEncomiendaDetalle { get; set; }

    public int IdPagoEncomienda { get; set; }

    public int IdTipoEncomienda { get; set; }

    public int IdPais { get; set; }

    public string Tracking { get; set; }

    public decimal PrecioFlete { get; set; }

    public decimal? DescuentoOtorgado { get; set; }

    public decimal? RecargoPorCombustible { get; set; }

    public bool? EstadoPagoEncomienda { get; set; }

    public string CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string ModificadoPor { get; set; }

    public DateTime FechaModificacion { get; set; }

    public virtual PagoEncomienda IdPagoEncomiendaNavigation { get; set; }

    public virtual Paises IdPaisNavigation { get; set; }

    public virtual TipoEncomienda IdTipoEncomiendaNavigation { get; set; }
}