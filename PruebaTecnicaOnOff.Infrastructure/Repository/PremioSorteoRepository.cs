using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaOnOff.Core.Entities;
using PruebaTecnicaOnOff.Infrastructure.Context;
using PruebaTecnicaOnOff.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Infrastructure.Repository
{
	public class PremioSorteoRepository : IPremioSorteoRepository
	{
		private readonly string _connectionString;
		private readonly PruebaTecnicaOnOffContext _context;
        public PremioSorteoRepository(IConfiguration configuration, PruebaTecnicaOnOffContext context)
        {
			_connectionString = configuration.GetConnectionString("adoConnectionString");
			_context = context;
		}
        public void InsertarPremio(PremioSorteo premio) 
		{
			premio.Id = Guid.NewGuid();
			using var connection = new SqlConnection(_connectionString);
			string query = "INSERT INTO PremioSorteo (Id, Name, Description, Amount) VALUES (@Id, @Name, @Description, @Amount)";
			SqlCommand sqlCommand = new SqlCommand(query, connection);
			sqlCommand.Parameters.AddWithValue("@Id", premio.Id);
			sqlCommand.Parameters.AddWithValue("@Name", premio.Name);
			sqlCommand.Parameters.AddWithValue("@Description", premio.Description);
			sqlCommand.Parameters.AddWithValue("@Amount", premio.Amount);

			connection.Open();
			sqlCommand.ExecuteNonQuery();
		}

		public bool ValidarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			return _context.NumeroAsignado.Any(p => p.Cliente == numeroAsignado.Cliente && p.Usuario == numeroAsignado.Usuario && p.Numero == numeroAsignado.Numero);
		}

		public void InsertarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			_context.Add(numeroAsignado);
			_context.SaveChanges();
		}

	}
}
