using Database.BLL.Entity;
using Database.DAL;
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
    public class OrganizationService
    {
        private readonly IOrganizationRepository _iOrganizationRepository;

        public OrganizationService(IOrganizationRepository iOrganizationRepository)
        {
            _iOrganizationRepository = iOrganizationRepository;
        }

        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            try
            {
                var organizationRepositoryEntity = await _iOrganizationRepository.GetByIdAsync(id);
                return organizationRepositoryEntity?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateOrganizationAsync(Organization organization)
        {
            try
            {
                var organizationEntity = organization.ToDAL();
                await _iOrganizationRepository.AddAsync(organizationEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            try
            {
                await _iOrganizationRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
