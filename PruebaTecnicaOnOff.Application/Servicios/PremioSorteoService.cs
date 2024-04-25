using PruebaTecnicaOnOff.Application.Servicios.IServicios;
using PruebaTecnicaOnOff.Core.Models;
using PruebaTecnicaOnOff.Core.RepositoryInterface;


namespace PruebaTecnicaOnOff.Application.Servicios
{
	public class PremioSorteoService : IPremioSorteoService
	{
        private readonly IPremioSorteoRepository _premioSorteoRepository;
        public PremioSorteoService(IPremioSorteoRepository premioSorteoRepository)
        {
            _premioSorteoRepository = premioSorteoRepository;
        }

        public void InsertarPremio(PremioSorteo premio)
        { 
            _premioSorteoRepository.InsertarPremio(premio);
        }

        public int InsertarNumeroAsignado(NumeroAsignado numeroAsignado) 
        {
            int numeroAsignar = GenerarNumeroAleatorio(numeroAsignado);
            _premioSorteoRepository.InsertarNumeroAsignado(numeroAsignado, numeroAsignar);
            return numeroAsignar;
        }

        private int GenerarNumeroAleatorio(NumeroAsignado numeroAsignado)
        {
            int numero;
            Random random = new();
            do
            {
                numero = random.Next(10000, 100000);
            } while (MasDeTresNumerosIguales(numero.ToString()) && _premioSorteoRepository.ValidarNumeroAsignado(numeroAsignado, numero));
            
            return numero;
		}


        private static bool MasDeTresNumerosIguales(string numero)
        {
			for (int i = 0; i < numero.Length - 2; i++)
			{
				if (numero[i] == numero[i + 1] && numero[i + 1] == numero[i + 2])
				{
					return true;
				}
			}
			return false;
		}
	}
}
