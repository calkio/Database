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
    public class InstallationWorkerRepository : IInstallationWorkerRepository
    {
        private readonly string _connectionString;

        public InstallationWorkerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(InstallationDAL installationDAL, WorkerDAL workerDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL add_installation_worker(@idinstallation_argument, @idworker_argument)", connection);
                command.Parameters.AddWithValue("@idinstallation_argument", installationDAL.Id);
                command.Parameters.AddWithValue("@idworker_argument", workerDAL.Id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_installation_worker_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
