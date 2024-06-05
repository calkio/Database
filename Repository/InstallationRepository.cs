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
                var command = new NpgsqlCommand("SELECT * FROM get_installation_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);

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
                var command = new NpgsqlCommand("CALL add_installation(@date_argument, @idorganization_argument)", connection);
                command.Parameters.AddWithValue("@date_argument", installationDAL.Date);
                command.Parameters.AddWithValue("@idorganization_argument", installationDAL.IdOrganization);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_installation_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}
