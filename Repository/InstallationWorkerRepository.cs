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

        public void Add(InstallationDAL installationDAL ,WorkerDAL workerDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO InstallationWorker (IdInstallation, IdWorker) " +
                                                "VALUES (@IdInstallation, @IdWorker)", connection);
                command.Parameters.AddWithValue("@IdInstallation", installationDAL.Id);
                command.Parameters.AddWithValue("@IdWorker", workerDAL.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM InstallationWorker WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
