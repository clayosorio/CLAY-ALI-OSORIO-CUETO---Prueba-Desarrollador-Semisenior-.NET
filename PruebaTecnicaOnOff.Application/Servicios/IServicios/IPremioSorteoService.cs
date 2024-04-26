using PruebaTecnicaOnOff.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Application.Servicios.IServicios
{
	public interface IPremioSorteoService
	{
		void InsertarPremio(PremioSorteo premio);
		Task<string> InsertarNumeroAsignado(NumeroAsignado numeroAsignado);
	}
}
