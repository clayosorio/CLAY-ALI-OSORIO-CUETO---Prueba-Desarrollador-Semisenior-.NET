using Microsoft.Extensions.Configuration;
using PruebaTecnicaOnOff.Core.Models;
using PruebaTecnicaOnOff.Core.RepositoryInterface;
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
        public PremioSorteoRepository(IConfiguration configuration)
        {
			_connectionString = configuration.GetConnectionString("connectionString");
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

		public bool ValidarNumeroAsignado(NumeroAsignado numeroAsignado, int numero)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			connection.Open();
			string query = "SELECT COUNT(*) FROM NumeroAsignado WHERE Client = @Cliente AND UserClient = @Usuario AND Numero = @Numero";
			using SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Client", numeroAsignado.Cliente);
			command.Parameters.AddWithValue("@Usuario", numeroAsignado.Usuario);
			command.Parameters.AddWithValue("@Numero", numero);
			int count = (int)command.ExecuteScalar();
			return count > 0;
		}

		public void InsertarNumeroAsignado(NumeroAsignado numeroAsignado, int numero)
		{ 
			numeroAsignado.Id = Guid.NewGuid();
			using var connection = new SqlConnection(_connectionString);
			string query = "INSERT INTO NumeroAsignado (Id, Client, UserClient, Number) VALUES (@Id, @Cliente, @Usuario, @Numero)";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Id", numeroAsignado.Id);
			command.Parameters.AddWithValue("@Cliente", numeroAsignado.Cliente);
			command.Parameters.AddWithValue("@Usuario", numeroAsignado.Usuario);
			command.Parameters.AddWithValue("@Numero", numero);

			connection.Open();
			command.ExecuteNonQuery();
		}

	}
}
