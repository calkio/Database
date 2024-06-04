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

        public IEnumerable<ReportDAL> GetAll()
        {
            var reportsDAL = new List<ReportDAL>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Report", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reportDAL = new ReportDAL();
                        reportDAL.Id = (int)reader["Id"];
                        reportDAL.Phototrace = (byte)reader["Phototrace"];
                        reportDAL.DateTime = (DateTime)reader["DateTime"];
                        reportDAL.Diagnosis = (bool)reader["Diagnosis"];
                        reportDAL.Height = (double)reader["Height"];
                        reportDAL.OutsideDiameter = (double)reader["OutsideDiameter"];
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

            if (reportsDAL.Count == 0 || reportsDAL == null)
            {
                throw new Exception("Был выдан пустой список");
            }

            return reportsDAL;
        }

        public ReportDAL GetById(int id)
        {
            ReportDAL reportDAL = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Report WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        reportDAL.Id = (int)reader["Id"];
                        reportDAL.Phototrace = (byte)reader["Phototrace"];
                        reportDAL.DateTime = (DateTime)reader["DateTime"];
                        reportDAL.Diagnosis = (bool)reader["Diagnosis"];
                        reportDAL.Height = (double)reader["Height"];
                        reportDAL.OutsideDiameter = (double)reader["OutsideDiameter"];
                        reportDAL.InnerDiameter = (double)reader["InnerDiameter"];
                        reportDAL.CoilDiameter = (double)reader["CoilDiameter"];
                        reportDAL.Perpendicularity = (double)reader["Perpendicularity"];
                        reportDAL.Kit = (int)reader["Kit"];
                        reportDAL.SpringMarker = (int)reader["SpringMarker"];
                        reportDAL.CartType = (string)reader["CartType"];
                        reportDAL.IdInstallationWorker = (int)reader["IdInstallationWorker"];
                    }
                }
            }

            if (reportDAL == null)
            {
                throw new Exception("Не нашлось отчета по такому Id");
            }

            return reportDAL;
        }

        public void Add(ReportDAL reportDAL)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO Report (Phototrace, DateTime, Diagnosis, Height, OutsideDiameter, InnerDiameter, CoilDiameter, Perpendicularity, Kit, SpringMarker, CartType, IdInstallationWorker) " +
                                                "VALUES (@Phototrace, @DateTime, @Diagnosis, @Height, @OutsideDiameter, @InnerDiameter, @CoilDiameter, @Perpendicularity, @Kit, @SpringMarker, @CartType, @IdInstallationWorker)", connection);
                command.Parameters.AddWithValue("@Phototrace", reportDAL.Phototrace);
                command.Parameters.AddWithValue("@DateTime", reportDAL.DateTime);
                command.Parameters.AddWithValue("@Diagnosis", reportDAL.Diagnosis);
                command.Parameters.AddWithValue("@Height", reportDAL.Height);
                command.Parameters.AddWithValue("@OutsideDiameter", reportDAL.OutsideDiameter);
                command.Parameters.AddWithValue("@InnerDiameter", reportDAL.InnerDiameter);
                command.Parameters.AddWithValue("@CoilDiameter", reportDAL.CoilDiameter);
                command.Parameters.AddWithValue("@Perpendicularity", reportDAL.Perpendicularity);
                command.Parameters.AddWithValue("@Kit", reportDAL.Kit);
                command.Parameters.AddWithValue("@SpringMarker", reportDAL.SpringMarker);
                command.Parameters.AddWithValue("@CartType", reportDAL.CartType);
                command.Parameters.AddWithValue("@IdInstallationWorker", reportDAL.IdInstallationWorker);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM Report WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
