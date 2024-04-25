using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaOnOff.Application.Servicios.IServicios;
using PruebaTecnicaOnOff.Core.Models;

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
		public async Task<IActionResult> InsertarPremio(PremioSorteo premio)
		{ 
			_premioSorteoService.InsertarPremio(premio);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> InsertarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			int result = _premioSorteoService.InsertarNumeroAsignado(numeroAsignado);
			return Ok(result);
		}
	}
}
