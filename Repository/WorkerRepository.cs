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
                var command = new NpgsqlCommand("SELECT * FROM get_worker_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);
                
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
                var command = new NpgsqlCommand("CALL add_worker(@lastname_argument, @firstname_argument, @middlename_argument)", connection);
                command.Parameters.AddWithValue("@lastname_argument", workerDAL.LastName);
                command.Parameters.AddWithValue("@firstname_argument", workerDAL.FirstName);
                command.Parameters.AddWithValue("@middlename_argument", workerDAL.MiddleName);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("CALL delete_worker_by_id(@id_argument)", connection);
                command.Parameters.AddWithValue("@id_argument", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
