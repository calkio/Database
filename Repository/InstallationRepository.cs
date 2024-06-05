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

        public async Task<InstallationDAL> GetByIdAsync(int id)
        {
            InstallationDAL installationDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM Installation WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        installationDAL = new InstallationDAL
                        {
                            Id = (int)reader["Id"],
                            Date = (DateOnly)reader["Date"],
                            IdOrganization = (int)reader["IdOrganization"]
                        };
                    }
                }
            }

            if (installationDAL == null)
            {
                throw new Exception("Не нашлось установки по такому Id");
            }

            return installationDAL;
        }

        public async Task AddAsync(InstallationDAL installationDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("INSERT INTO Installation (StartDate, IdOrganization) " +
                                                "VALUES (@StartDate, @IdOrganization)", connection);
                command.Parameters.AddWithValue("@StartDate", installationDAL.Date);
                command.Parameters.AddWithValue("@IdOrganization", installationDAL.IdOrganization);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("DELETE FROM Installation WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}
