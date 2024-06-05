using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository.Interface
{
    public interface IWorkerRepository
    {
        public Task<WorkerDAL> GetByIdAsync(int id);
        public Task AddAsync(WorkerDAL workerDAL);
        public Task DeleteAsync(int id);
    }
}
