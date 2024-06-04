using Database.BLL.Entity;
using Database.Mapper;
using Database.Repository;
using Database.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.BLL.Service
{
    public class WorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public Worker GetWorkerById(int id)
        {
            try
            {
                var installationEntities = _workerRepository.GetByid(id);
                return installationEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateWorker(Worker worker)
        {
            try
            {
                var workerEntity = worker.ToDAL();
                _workerRepository.Add(workerEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWorker(int id)
        {
            try
            {
                _workerRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
