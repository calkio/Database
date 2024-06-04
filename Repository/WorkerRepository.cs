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
