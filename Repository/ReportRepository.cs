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
    public class ReportRepository : IReportRepository
    {
        private readonly string _connectionString;

        public ReportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ReportDAL>> GetAllAsync()
        {
            var reportsDAL = new List<ReportDAL>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM Report", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var reportDAL = new ReportDAL();
                        reportDAL.Id = (int)reader["Id"];
                        reportDAL.Photogate = (byte[])reader["Photogate"];
                        reportDAL.DateTime = (DateTime)reader["DateTime"];
                        reportDAL.Diagnosis = (bool)reader["Diagnosis"];
                        reportDAL.Height = (double)reader["Height"];
                        reportDAL.Outerdiameter = (double)reader["Outerdiameter"];
                        reportDAL.InnerDiameter = (double)reader["InnerDiameter"];
                        reportDAL.CoilDiameter = (double)reader["CoilDiameter"];
                        reportDAL.Perpendicularity = (double)reader["Perpendicularity"];
                        reportDAL.Kit = (int)reader["Kit"];
                        reportDAL.SpringMarker = (int)reader["SpringMarker"];
                        reportDAL.CartType = (string)reader["CartType"];
                        reportDAL.IdInstallationWorker = (int)reader["IdInstallationWorker"];

                        reportsDAL.Add(reportDAL);
                    }
                }
            }

            if (reportsDAL.Count == 0)
            {
                throw new Exception("Был выдан пустой список");
            }

            return reportsDAL;
        }

        public async Task<ReportDAL> GetByIdAsync(int id)
        {
            ReportDAL reportDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("SELECT * FROM Report WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        reportDAL = new ReportDAL
                        {
                            Id = (int)reader["Id"],
                            Photogate = (byte[])reader["Photogate"],
                            DateTime = (DateTime)reader["DateTime"],
                            Diagnosis = (bool)reader["Diagnosis"],
                            Height = (double)reader["Height"],
                            Outerdiameter = (double)reader["Outerdiameter"],
                            InnerDiameter = (double)reader["InnerDiameter"],
                            CoilDiameter = (double)reader["CoilDiameter"],
                            Perpendicularity = (double)reader["Perpendicularity"],
                            Kit = (int)reader["Kit"],
                            SpringMarker = (int)reader["SpringMarker"],
                            CartType = (string)reader["CartType"],
                            IdInstallationWorker = (int)reader["IdInstallationWorker"]
                        };
                    }
                }
            }

            if (reportDAL == null)
            {
                throw new Exception("Не нашлось отчета по такому Id");
            }

            return reportDAL;
        }

        public async Task AddAsync(ReportDAL reportDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("INSERT INTO Report (Photogate, DateTime, Diagnosis, Height, Outerdiameter, InnerDiameter, CoilDiameter, Perpendicularity, Kit, SpringMarker, CartType, IdInstallationWorker) " +
                                                "VALUES (@Photogate, @DateTime, @Diagnosis, @Height, @Outerdiameter, @InnerDiameter, @CoilDiameter, @Perpendicularity, @Kit, @SpringMarker, @CartType, @IdInstallationWorker)", connection);
                command.Parameters.AddWithValue("@Photogate", reportDAL.Photogate);
                command.Parameters.AddWithValue("@DateTime", reportDAL.DateTime);
                command.Parameters.AddWithValue("@Diagnosis", reportDAL.Diagnosis);
                command.Parameters.AddWithValue("@Height", reportDAL.Height);
                command.Parameters.AddWithValue("@Outerdiameter", reportDAL.Outerdiameter);
                command.Parameters.AddWithValue("@InnerDiameter", reportDAL.InnerDiameter);
                command.Parameters.AddWithValue("@CoilDiameter", reportDAL.CoilDiameter);
                command.Parameters.AddWithValue("@Perpendicularity", reportDAL.Perpendicularity);
                command.Parameters.AddWithValue("@Kit", reportDAL.Kit);
                command.Parameters.AddWithValue("@SpringMarker", reportDAL.SpringMarker);
                command.Parameters.AddWithValue("@CartType", reportDAL.CartType);
                command.Parameters.AddWithValue("@IdInstallationWorker", reportDAL.IdInstallationWorker);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new NpgsqlCommand("DELETE FROM Report WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
