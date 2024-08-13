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

namespace FacturasSAP.DatAccess.Repositories
{
    public class TipoExoneracionRepository : IListRepository<TipoExoneracionModel>
    {
        public async Task<ModelResult<TipoExoneracionModel>> listAsync()
        {
            try
			{
				using var db = new FacturaSAPContext();
				ModelResult<TipoExoneracionModel> resul = new ModelResult<TipoExoneracionModel>();
                var data = await db.TipoExoneradoSAP.Where(a=> a.EstadoTipoExonerado == true).ToListAsync();
				if(data.Count==0) return new ModelResult<TipoExoneracionModel>() { Success= false, Message = "No se encontraron datos"};
				resul.Success = true;
				resul.Message = "Exitosamente";
				resul.Data =  data.Select(a=> new TipoExoneracionModel {
					IdTipoExonerado = a.IdTipoExonerado, 
					Codigo = a.Codigo,
					Nombre = a.Nombre,
				}).ToList();
				return resul;
			}
			catch (Exception ex)
			{
				return new ModelResult<TipoExoneracionModel>() { Success = false, Message = $"Error: {ex}" };
			}
        }
    }
}
