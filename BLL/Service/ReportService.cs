using Database.BLL.Entity;
using Database.DAL;
using Database.Mapper;
using Database.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.BLL.Service
{
    public class ReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IEnumerable<Report> GetAllReport()
        {
            try
            {
                var reportEntities = _reportRepository.GetAll();
                return reportEntities.Select(e => e.ToBLL());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Report GetReportById(int id)
        {
            try
            {
                var reportRepositoryEntity = _reportRepository.GetById(id);
                return reportRepositoryEntity?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateReport(Report report)
        {
            try
            {
                var reportEntity = report.ToDAL();
                _reportRepository.Add(reportEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteReport(int id)
        {
            try
            {
                _reportRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
