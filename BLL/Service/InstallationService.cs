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
    public class InstallationService
    {
        private readonly IInstallationRepository _installationRepository;

        public InstallationService(IInstallationRepository installationRepository)
        {
            _installationRepository = installationRepository;
        }

        public Installation GetInstallationById(int id)
        {
            try
            {
                var installationEntities = _installationRepository.GetByid(id);
                return installationEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateInstallation(Installation installation)
        {
            try
            {
                var installationEntity = installation.ToDAL();
                _installationRepository.Add(installationEntity);
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
                _installationRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
