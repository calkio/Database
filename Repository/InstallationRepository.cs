using Database.DAL;
using Database.Repository.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class InstallationRepository : IInstallationRepository
    {
        private readonly string _connectionString;

        public InstallationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public InstallationDAL GetByid(int id)
        {
            InstallationDAL installationDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Installation WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        installationDAL.Id = (int)reader["Id"];
                        installationDAL.Date = (DateOnly)reader["Date"];
                        installationDAL.IdOrganization = (int)reader["IdOrganization"];
                    }
                }
            }

            if (installationDAL == null)
            {
                throw new Exception("Не нашлось отчета по такому Id");
            }

            return installationDAL;
        }

        public void Add(InstallationDAL installationDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO Installation (StartDate, IdOrganization) " +
                                                "VALUES (@StartDate, @IdOrganization)", connection);
                command.Parameters.AddWithValue("@StartDate", installationDAL.Date);
                command.Parameters.AddWithValue("@IdOrganization", installationDAL.IdOrganization);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM Installation WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
