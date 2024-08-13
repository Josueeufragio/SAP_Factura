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
    public class PaisRepository : IListRepository<PaisModel>
    {
        public async Task<ModelResult<PaisModel>> listAsync()
        {
			try
			{
				using var db = new FacturaSAPContext();
				ModelResult<PaisModel> resul = new ModelResult<PaisModel>();
                var data = await db.Paises.Where(a=> a.EstadoPais).ToListAsync();
				if(data.Count==0) return new ModelResult<PaisModel>() { Success= false, Message = "No se encontraron datos"};
				resul.Success = true;
				resul.Message = "Exitosamente";
				resul.Data =  data.Select(a=> new PaisModel {IdPais = a.IdPais, Pais = a.PaisEspaniol, codigo = a.CodigoMap}).ToList();
				return resul;
			}
			catch (Exception ex)
			{
				return new ModelResult<PaisModel>() { Success = false, Message = $"Error: {ex}" };
			}
        }
    }
}
