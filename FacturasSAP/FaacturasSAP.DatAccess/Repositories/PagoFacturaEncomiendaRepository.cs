using FacturasSAP.Common.Models.Configuracion;
using FacturasSAP.Common.Models.Encomienda;
using FacturasSAP.DataAccess.Repositories.Interface;
using FacturasSAP.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.DataAccess.Repositories
{
    public class PagoFacturaEncomiendaRepository : IPagoFecturaEncomiendaRepository<PagoEncomiendaModel>
    {
     
        public async Task<ModelResult<bool>> guardarAsync(PagoEncomiendaModel model)
        {
            try
            {
                using var db = new FacturaSAPContext();
                var nuevoPagoEncomienda = new PagoEncomienda
                {
                    CodigoSAP = model.CodigoSAP,
                    IdRetencionImpuesto = model.IdRetencionImpuesto,
                    IdTipoExoneradoSAP = model.IdTipoExoneradoSAP,
                    Dolar = model.Dolar,
                    //FacturaSAP = model.FacturaSAP,
                    Fecha = model.Fecha,
                    FechaVencimiento = model.Fecha,
                    EnviadoSAP = false,
                    EstadoPagoEncomienda = true,
                    CreadoPor = "",
                    FechaCreacion = DateTime.Now,
                    ModificadoPor = "",
                    FechaModificacion = DateTime.Now,
                    // Lista de detalles de pago asociados
                    PagoEncomiendaDetalle = model.PagosEncomiendaDetalle.Select(d => new PagoEncomiendaDetalle
                    {
                        IdTipoEncomienda = d.IdTipoEncomienda,
                        IdPais = d.IdPais,
                        Tracking = d.Traking,
                        PrecioFlete = d.PrecioFlete,
                        DescuentoOtorgado = d.DescuentoOtorgado,
                        RecargoPorCombustible = d.RecargoPorCombustible,
                        //EstadoPagoEncomiendaDetalle = d.Estado,
                        EstadoPagoEncomienda = true,
                        CreadoPor = "",
                        FechaCreacion = DateTime.Now,
                        ModificadoPor = "",
                        FechaModificacion = DateTime.Now,

                    }).ToList()
                };

                // Agregar al contexto
                db.PagoEncomienda.Add(nuevoPagoEncomienda);

                // Guardar en la base de datos
                int value = await db.SaveChangesAsync();
                if (value == 0) return new ModelResult<bool>() { Success = false, Message= $"No se guardo"};
                return new ModelResult<bool>() { Success = true, Message = "Creado Correctamente" };
            }
            catch (Exception ex)
            {
                return new ModelResult<bool>() { Success = false, Message= $"Error {ex}"};
            }
        }

        public async Task<ModelResult<PagoEncomiendaModel>> listAsync()
        {
            try
            {
                using var db = new FacturaSAPContext();
                ModelResult<PagoEncomiendaModel> resul = new ModelResult<PagoEncomiendaModel>();
                var pagoEnc = await db.PagoEncomienda.ToListAsync();

                resul.Success = pagoEnc.Count > 0;
                resul.Message = resul.Success ? "Datos Octenidos Correctamente": "No tiene Datos";
                resul.Data = pagoEnc.Select(a => new PagoEncomiendaModel
                {
                    Id = a.IdPagoEncomienda,
                    IdRetencionImpuesto = a.IdRetencionImpuesto
                }).ToList();
                return resul;
            }
            catch (Exception ex)
            {
                return new ModelResult<PagoEncomiendaModel> { Message = ex.Message ,Success = false};
            }
        }

        public async Task<ModelResult<PagoEncomiendaModel>> whereAsync(int id)
        {
            try
            {
                using var db = new FacturaSAPContext();
                ModelResult<PagoEncomiendaModel> resul = new ModelResult<PagoEncomiendaModel>();
                var data = await db.PagoEncomienda
                .Include(pe => pe.PagoEncomiendaDetalle)
                .ThenInclude(ped => ped.IdTipoEncomiendaNavigation)
                .FirstOrDefaultAsync(pe => pe.IdPagoEncomienda == id);
                if (data == null) return new ModelResult<PagoEncomiendaModel>() { Message = "No se encontro la Factura", Success = false };

                resul.Value = new PagoEncomiendaModel
                {
                    Id = data.IdPagoEncomienda,
                    IdRetencionImpuesto = data.IdRetencionImpuesto,
                    PagosEncomiendaDetalle = 
                        data?.PagoEncomiendaDetalle.Select(a=> new PagosEncomiendaDetalleModel { 
                            IdPagoEncomienda = a.IdPagoEncomienda, 
                            Lugar = a.IdPaisNavigation.Pais,
                            Traking = a.Tracking,
                            PrecioFlete = a.PrecioFlete,
                            DescuentoOtorgado = a.DescuentoOtorgado?? decimal.Zero,
                            RecargoPorCombustible = a.RecargoPorCombustible?? decimal.Zero,
                            CreadoPor = a.CreadoPor,
                            FechaCreacion = a.FechaCreacion,
                            ModificadoPor = a.ModificadoPor,

                        }).ToList() 
                        ?? new List<PagosEncomiendaDetalleModel>(),

                };
                return resul;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
