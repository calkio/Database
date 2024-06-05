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
    public class InstallationWorkerService
    {
        private readonly IInstallationWorkerRepository _installationWorkerRepository;

        public InstallationWorkerService(IInstallationWorkerRepository installationWorkerRepository)
        {
            _installationWorkerRepository = installationWorkerRepository;
        }

        public async Task AddInstallationWorkerAsync(InstallationDAL installationDAL, WorkerDAL workerDAL)
        {
            try
            {
                await _installationWorkerRepository.AddAsync(installationDAL, workerDAL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteInstallationWorkerAsync(int id)
        {
            try
            {
                await _installationWorkerRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
