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

        public void CreateInstallation(Installation installation, Worker worker)
        {
            try
            {
                var installationEntity = installation.ToDAL();
                var workerEntity = worker.ToDAL();
                _installationWorkerRepository.Add(installationEntity, workerEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteInstallation(int id)
        {
            try
            {
                _installationWorkerRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
