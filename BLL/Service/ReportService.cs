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

        public async Task<IEnumerable<Report>> GetAllReportAsync()
        {
            try
            {
                var reportEntities = await _reportRepository.GetAllAsync();
                return reportEntities.Select(e => e.ToBLL());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            try
            {
                var reportRepositoryEntity = await _reportRepository.GetByIdAsync(id);
                return reportRepositoryEntity?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateReportAsync(Report report)
        {
            try
            {
                var reportEntity = report.ToDAL();
                await _reportRepository.AddAsync(reportEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteReportAsync(int id)
        {
            try
            {
                await _reportRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
