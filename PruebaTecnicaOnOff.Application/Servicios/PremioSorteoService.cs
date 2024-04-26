using PruebaTecnicaOnOff.Application.Servicios.IServicios;
using PruebaTecnicaOnOff.Core.Entities;
using PruebaTecnicaOnOff.Infrastructure.Repositorio.IRepositorio;
using System.Text.RegularExpressions;


namespace PruebaTecnicaOnOff.Application.Servicios
{
	public class PremioSorteoService : IPremioSorteoService
	{
        private readonly IPremioSorteoRepository _premioSorteoRepository;
		const int LONGITUD_NUMERO = 5;
		public PremioSorteoService(IPremioSorteoRepository premioSorteoRepository)
        {
            _premioSorteoRepository = premioSorteoRepository;
        }

        public void InsertarPremio(PremioSorteo premio)
        { 
            _premioSorteoRepository.InsertarPremio(premio);
        }

        public async Task<string> InsertarNumeroAsignado(NumeroAsignado numeroAsignado) 
        {
			string numeroAsignar = await GenerarNumeroAleatorio(numeroAsignado);
			numeroAsignado.Numero = numeroAsignar;
			_premioSorteoRepository.InsertarNumeroAsignado(numeroAsignado);
			return numeroAsignar;
		}

        private async Task<string> GenerarNumeroAleatorio(NumeroAsignado numeroAsignado)
        {
			string numero;
			Random random = new();
			do
			{
				numero = random.Next(1, 100000).ToString().PadLeft(LONGITUD_NUMERO, '0');
				numeroAsignado.Numero = numero;
			} while (MasDeTresNumerosIguales(numero.ToString()) && await _premioSorteoRepository.ValidarNumeroAsignado(numeroAsignado));

			return numero;
		}


        private static bool MasDeTresNumerosIguales(string numero)
        {
			string patron = @"(\d)\1{2}";
			Match coincidencia = Regex.Match(numero, patron);
			return coincidencia.Success;
		}
	}
}
