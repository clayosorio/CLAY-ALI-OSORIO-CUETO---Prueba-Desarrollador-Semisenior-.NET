using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaOnOff.Application.Servicios.IServicios;
using PruebaTecnicaOnOff.Core.Entities;

namespace PruebaTecnicaOnOff.Api.Controlador
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class SorteoController : ControllerBase
	{
		IPremioSorteoService _premioSorteoService;
        public SorteoController(IPremioSorteoService premioSorteoService)
        {
			_premioSorteoService = premioSorteoService;
        }

        [HttpPost]
		public ActionResult InsertarPremio(PremioSorteo premio)
		{ 
			_premioSorteoService.InsertarPremio(premio);
			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			string result = await _premioSorteoService.InsertarNumeroAsignado(numeroAsignado);
			return Ok(result);
		}
	}
}
