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

        public async Task<OrganizationDAL> GetByIdAsync(int id)
        {
            OrganizationDAL organizationDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM Organization WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        organizationDAL = new OrganizationDAL
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            NumberOfSetups = (int)reader["NumberOfSetups"]
                        };
                    }
                }
            }

            if (organizationDAL == null)
            {
                throw new Exception("Не нашлось отчета по такому Id");
            }

            return organizationDAL;
        }

        public async Task AddAsync(OrganizationDAL organizationDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("INSERT INTO Organization (Name, NumberOfSetups) " +
                                                "VALUES (@Name, @NumberOfSetups)", connection);
                command.Parameters.AddWithValue("@Name", organizationDAL.Name);
                command.Parameters.AddWithValue("@NumberOfSetups", organizationDAL.NumberOfSetups);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("DELETE FROM Organization WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}
