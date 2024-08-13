using FacturasSAP.Common.Models.Configuracion;
using FacturasSAP.Common.Models.Encomienda;
using FacturasSAP.DataAccess;
using FacturasSAP.DatAccess.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturasSAP.DatAccess.Repositories
{
    public class EncomiendaRepositorty : IListRepository<EncomiendasPendientesModel>
    {
        public async Task<ModelResult<EncomiendasPendientesModel>> listAsync()
        {
			try
            { 
                var db = new FacturaSAPContext();
				ModelResult<EncomiendasPendientesModel> result = new();
                result.Data = new List<EncomiendasPendientesModel>();
                using SqlConnection connection = new(db.Database.GetConnectionString());
                await connection.OpenAsync();

                using SqlCommand command = new("dbo.sp_EncomiendasPendiente", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 0;

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    string json = reader.GetString(0);
                    var item = JsonConvert.DeserializeObject<EncomiendasPendientesModel>(json);
                    if (item == null) continue;
                    result.Data.Add(item);
                }
                await reader.DisposeAsync();
                await reader.CloseAsync();

            return result;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
