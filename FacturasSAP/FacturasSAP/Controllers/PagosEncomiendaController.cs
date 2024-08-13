using FacturasSAP.BusinessLogic.Services;
using FacturasSAP.Common.Models.Configuracion;
using FacturasSAP.Common.Models.Encomienda;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacturasSAP.Controllers
{
    public class PagosEncomiendaController : Controller
    {
        private readonly PagoEncomiendaServices _pagoEncomiendaServices;
        public PagosEncomiendaController(PagoEncomiendaServices pagoEncomiendaServices)
        {
            _pagoEncomiendaServices = pagoEncomiendaServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CrearPagosEncomiendas()
        {
            var result = new PagoEncomiendaModel();
            var listRetencion = await _pagoEncomiendaServices.ListAsyncTipoRetencion();
            ViewBag.TipoRetencion = listRetencion.Success? new SelectList(listRetencion.Data.Select(a => new SelectListItem {Text = a.Nombre, Value = a.IdRetencionImpuestos.ToString() }).ToList(), "Value", "Text"): new SelectList(null);
            var listExoneracion = await _pagoEncomiendaServices.listAsyncTipoExoneracion();
            ViewBag.TipoExoneracion = listExoneracion.Success? new SelectList(listExoneracion.Data.Select(a => new SelectListItem { Text = a.Nombre, Value = a.IdTipoExonerado.ToString()}).ToList(), "Value", "Text"): new  SelectList(null);
            var listpais = await _pagoEncomiendaServices.ListAsyncPais();
            result.paisList = listpais.Success? listpais.Data: new List<PaisModel>();
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> GuardarPagosEncomiendas(PagoEncomiendaModel model)
        {
            var result = await _pagoEncomiendaServices.Guardar(model);
            return Json(result);
        }
    }
}
