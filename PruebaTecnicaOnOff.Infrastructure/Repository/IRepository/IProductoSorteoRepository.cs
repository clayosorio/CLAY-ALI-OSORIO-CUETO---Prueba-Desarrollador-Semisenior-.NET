using PruebaTecnicaOnOff.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Infrastructure.Repository.IRepository
{
	public interface IPremioSorteoRepository
	{
		void InsertarPremio(PremioSorteo premio);
		bool ValidarNumeroAsignado(NumeroAsignado numeroAsignado);
		void InsertarNumeroAsignado(NumeroAsignado numeroAsignado);
	}
}
