using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Core.Models
{
	public class PremioSorteo
	{
		[JsonIgnore]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public int? Amount { get; set; }
	}
}
