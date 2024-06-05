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

        public async Task<Installation> GetInstallationByIdAsync(int id)
        {
            try
            {
                var installationRepositoryEntity = await _installationRepository.GetByIdAsync(id);
                return installationRepositoryEntity?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateInstallationAsync(Installation installation)
        {
            try
            {
                var installationEntity = installation.ToDAL();
                await _installationRepository.AddAsync(installationEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteInstallationAsync(int id)
        {
            try
            {
                await _installationRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
