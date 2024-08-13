using FacturasSAP.BusinessLogic.Services;
using FacturasSAP.DataAccess;
using FacturasSAP.DataAccess.Repositories;

namespace FacturasSAP
{
    public static class ServicesConfiguretion
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<PagoFacturaRepository>();
            FacturaSAPContext.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<PagoEncomiendaServices>();
        }
    }
}
