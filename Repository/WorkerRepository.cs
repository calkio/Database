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

        public WorkerDAL GetByid(int id)
        {
            WorkerDAL workerDAL = new WorkerDAL();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Worker WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        workerDAL.Id = (int)reader["Id"];
                        workerDAL.LastName = (string)reader["LastName"];
                        workerDAL.FirstName = (string)reader["FirstName"];
                        workerDAL.MiddleName = (string)reader["MiddleName"];
                    }
                }
            }

            if (workerDAL == null)
            {
                throw new Exception("Не нашлось отчета по такому Id");
            }

            return workerDAL;
        }

        public void Add(WorkerDAL workerDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO Worker (LastName, FirstName, MiddleName) " +
                                                "VALUES (@LastName, @FirstName, @MiddleName)", connection);
                command.Parameters.AddWithValue("@LastName", workerDAL.LastName);
                command.Parameters.AddWithValue("@FirstName", workerDAL.FirstName);
                command.Parameters.AddWithValue("@MiddleName", workerDAL.MiddleName);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM Worker WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
