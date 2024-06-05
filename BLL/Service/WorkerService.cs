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

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            try
            {
                var workerRepositoryEntity = await _workerRepository.GetByIdAsync(id);
                return workerRepositoryEntity?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateWorkerAsync(Worker worker)
        {
            try
            {
                var workerEntity = worker.ToDAL();
                await _workerRepository.AddAsync(workerEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteWorkerAsync(int id)
        {
            try
            {
                await _workerRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
