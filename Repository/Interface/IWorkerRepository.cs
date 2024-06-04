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
        public WorkerDAL GetByid(int id);
        public void Add(WorkerDAL workerDAL);
        public void Delete(int id);
    }
}
