using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Core.Models
{
	public class NumeroAsignado
	{
		[JsonIgnore]
		public Guid Id { get; set; }
		public string Cliente { get; set; }
		public string Usuario { get; set; }
	}
}
