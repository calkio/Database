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
    public class WorkerRepository : IWorkerRepository
    {
        private readonly string _connectionString;

        public WorkerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<WorkerDAL> GetByIdAsync(int id)
        {
            WorkerDAL workerDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM Worker WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        workerDAL = new WorkerDAL
                        {
                            Id = (int)reader["Id"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"],
                            MiddleName = (string)reader["MiddleName"]
                        };
                    }
                }
            }

            if (workerDAL == null)
            {
                throw new Exception("Не нашлось отчета по такому Id");
            }

            return workerDAL;
        }

        public async Task AddAsync(WorkerDAL workerDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("INSERT INTO Worker (LastName, FirstName, MiddleName) " +
                                                "VALUES (@LastName, @FirstName, @MiddleName)", connection);
                command.Parameters.AddWithValue("@LastName", workerDAL.LastName);
                command.Parameters.AddWithValue("@FirstName", workerDAL.FirstName);
                command.Parameters.AddWithValue("@MiddleName", workerDAL.MiddleName);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("DELETE FROM Worker WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
