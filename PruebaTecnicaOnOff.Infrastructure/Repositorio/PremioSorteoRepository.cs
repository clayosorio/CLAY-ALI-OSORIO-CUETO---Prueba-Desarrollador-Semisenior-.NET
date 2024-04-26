using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaOnOff.Core.Entities;
using PruebaTecnicaOnOff.Infrastructure.Context;
using PruebaTecnicaOnOff.Infrastructure.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Infrastructure.Repositorio
{
	public class PremioSorteoRepository : IPremioSorteoRepository
	{
		private readonly string _connectionString;
		private readonly PruebaTecnicaOnOffContext _context;
		public PremioSorteoRepository(IConfiguration configuration, PruebaTecnicaOnOffContext context)
		{
			_connectionString = configuration.GetConnectionString("adoConnectionString") ?? throw new NullReferenceException("Configurar cadena de conexión en settings");
			_context = context;
		}
		public void InsertarPremio(PremioSorteo premio)
		{
			premio.Id = Guid.NewGuid();
			using var connection = new SqlConnection(_connectionString);
			string query = "INSERT INTO PremioSorteo (Id, Nombre, Descripcion, Valor) VALUES (@Id, @Nombre, @Descripcion, @Valor)";
			SqlCommand sqlCommand = new SqlCommand(query, connection);
			sqlCommand.Parameters.AddWithValue("@Id", premio.Id);
			sqlCommand.Parameters.AddWithValue("@Nombre", premio.Nombre);
			sqlCommand.Parameters.AddWithValue("@Descripcion", premio.Descripcion);
			sqlCommand.Parameters.AddWithValue("@Valor", premio.Valor);

			connection.Open();
			sqlCommand.ExecuteNonQuery();
		}

		public async Task<bool> ValidarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			return await _context.NumeroAsignado.AnyAsync(p => p.Cliente == numeroAsignado.Cliente && p.Usuario == numeroAsignado.Usuario && p.Numero == numeroAsignado.Numero);
		}

		public void InsertarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			_context.Add(numeroAsignado);
			_context.SaveChanges();
		}

	}
}
