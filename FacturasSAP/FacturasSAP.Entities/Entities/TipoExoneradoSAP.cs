﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FacturasSAP.Entities.Entities;

public partial class TipoExoneradoSAP
{
    public int IdTipoExonerado { get; set; }

    public string Codigo { get; set; }

    public string Nombre { get; set; }

    public bool? EstadoTipoExonerado { get; set; }

    public string CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public decimal? Porcentaje { get; set; }

    public virtual ICollection<PagoEncomienda> PagoEncomienda { get; set; } = new List<PagoEncomienda>();
}