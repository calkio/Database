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
        public IEnumerable<ReportDAL> GetAll();
        public ReportDAL GetById(int id);
        public void Add(ReportDAL reportDAL);
        public void Delete(int id);
    }
}
