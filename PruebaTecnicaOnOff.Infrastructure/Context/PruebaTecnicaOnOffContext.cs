using Microsoft.EntityFrameworkCore;
using PruebaTecnicaOnOff.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Infrastructure.Context
{
	public class PruebaTecnicaOnOffContext : DbContext
	{
		public PruebaTecnicaOnOffContext() { }

		public DbSet<NumeroAsignado> NumeroAsignado { get; set; }

		public PruebaTecnicaOnOffContext(DbContextOptions options) : base(options)
		{
		}
	}
}
