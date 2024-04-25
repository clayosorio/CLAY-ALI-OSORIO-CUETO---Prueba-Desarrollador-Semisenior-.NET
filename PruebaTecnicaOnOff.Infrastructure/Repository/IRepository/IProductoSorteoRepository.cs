using PruebaTecnicaOnOff.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Core.RepositoryInterface
{
    public interface IPremioSorteoRepository
	{
		void InsertarPremio(PremioSorteo premio);
		bool ValidarNumeroAsignado(NumeroAsignado numeroAsignado, int numero);
		void InsertarNumeroAsignado(NumeroAsignado numeroAsignado, int numero);
	}
}
