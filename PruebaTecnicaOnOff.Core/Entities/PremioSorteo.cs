using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Core.Entities
{
	public class PremioSorteo
	{
		[JsonIgnore]
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public string? Descripcion { get; set; }
		public int? Valor { get; set; }
	}
}
