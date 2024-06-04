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
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly string _connectionString;

        public OrganizationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OrganizationDAL GetByid(int id)
        {
            OrganizationDAL organizationDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Organization WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        organizationDAL.Id = (int)reader["Id"];
                        organizationDAL.Name = (string)reader["Name"];
                        organizationDAL.NumberOfSetups = (int)reader["NumberOfSetups"];
                    }
                }
            }

            if (organizationDAL == null)
            {
                throw new Exception("Не нашлось отчета по такому Id");
            }

            return organizationDAL;
        }

        public void Add(OrganizationDAL organizationDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO Organization (Name, NumberOfSetups) " +
                                                "VALUES (@Name, @NumberOfSetups)", connection);
                command.Parameters.AddWithValue("@Name", organizationDAL.Name);
                command.Parameters.AddWithValue("@NumberOfSetups", organizationDAL.NumberOfSetups);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM Organization WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
