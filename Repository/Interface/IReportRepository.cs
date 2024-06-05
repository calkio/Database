using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository.Interface
{
    public interface IReportRepository
    {
        public Task<IEnumerable<ReportDAL>> GetAllAsync();
        public Task<ReportDAL> GetByIdAsync(int id);
        public Task AddAsync(ReportDAL reportDAL);
        public Task DeleteAsync(int id);
    }
}
