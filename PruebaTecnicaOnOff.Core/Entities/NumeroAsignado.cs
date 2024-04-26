using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Core.Entities
{
	public class NumeroAsignado
	{
		[JsonIgnore]
		[Key]
		public Guid Id { get; set; }
		public string Cliente { get; set; }
		public string Usuario { get; set; }
		[JsonIgnore]
		public string? Numero { get; set; }
	}
}
