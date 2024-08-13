using FacturasSAP.BusinessLogic.Services;
using FacturasSAP.DataAccess;
using FacturasSAP.DataAccess.Repositories;
using FacturasSAP.DatAccess.Repositories;

namespace FacturasSAP
{
    public static class ServicesConfiguretion
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<PagoFacturaEncomiendaRepository>();
            services.AddScoped<TipoExoneracionRepository>();
            services.AddScoped<TipoRetencionRepository>();
            services.AddScoped<PaisRepository>();
            services.AddScoped<EncomiendaRepositorty>();
            FacturaSAPContext.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<PagoEncomiendaServices>();
        }
    }
}
