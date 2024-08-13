using FacturasSAP.Common.Models.Configuracion;
using FacturasSAP.Common.Models.Encomienda;
using FacturasSAP.DataAccess;
using FacturasSAP.DatAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FacturasSAP.DatAccess.Repositories
{
    public class TipoRetencionRepository : IListRepository<TipoRetencionModel>
    {
        public async Task<ModelResult<TipoRetencionModel>> listAsync()
        {
			try
			{
				using var db = new FacturaSAPContext();
				ModelResult<TipoRetencionModel> resul = new ModelResult<TipoRetencionModel>();
                var data = await db.RetencionImpuestos.Where(a=> a.EstadoRetencion == true).ToListAsync();
				if(data.Count==0) return new ModelResult<TipoRetencionModel>() { Success= false, Message = "No se encontraron datos"};
				resul.Success = true;
				resul.Message = "Exitosamente";
				resul.Data =  data.Select(a=> new TipoRetencionModel {
					IdRetencionImpuestos = a.IdRetencionImpuesto, 
					Codigo = a.Codigo, Tasa = a.Tasa,
					Nombre = a.Nombre,
				}).ToList();
				return resul;
			}
			catch (Exception ex)
			{
				return new ModelResult<TipoRetencionModel>() { Success = false, Message = $"Error: {ex}" };
			}
        }
    }
}
