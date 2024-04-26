using PruebaTecnicaOnOff.Application.Servicios.IServicios;
using PruebaTecnicaOnOff.Core.Entities;
using PruebaTecnicaOnOff.Infrastructure.Repository.IRepository;
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

        public string InsertarNumeroAsignado(NumeroAsignado numeroAsignado) 
        {
			string numeroAsignar = GenerarNumeroAleatorio(numeroAsignado);
			numeroAsignado.Numero = numeroAsignar;
			_premioSorteoRepository.InsertarNumeroAsignado(numeroAsignado);
			return numeroAsignar;
		}

        private string GenerarNumeroAleatorio(NumeroAsignado numeroAsignado)
        {
			string numero;
			Random random = new();
			do
			{
				numero = random.Next(1, 100000).ToString().PadLeft(LONGITUD_NUMERO, '0');
				numeroAsignado.Numero = numero;
			} while (MasDeTresNumerosIguales(numero.ToString()) && _premioSorteoRepository.ValidarNumeroAsignado(numeroAsignado));

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
