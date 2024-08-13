using FacturasSAP.BusinessLogic.Services;
using FacturasSAP.Common.Models.Encomienda;
using FacturasSAP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FacturasSAP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PagoEncomiendaServices _pagoEncomiendaServices;

        public HomeController(ILogger<HomeController> logger, PagoEncomiendaServices pagoEncomiendaServices)
        {
            _logger = logger;
            _pagoEncomiendaServices = pagoEncomiendaServices;

        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListaPagos()
        {
            var data = await _pagoEncomiendaServices.ListaPagos();

            return View(data.Success ? data.Data : new List<PagoEncomiendaModel>());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
