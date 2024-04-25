using PruebaTecnicaOnOff.Core.Models;
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
		int InsertarNumeroAsignado(NumeroAsignado numeroAsignado);
	}
}
