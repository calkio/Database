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
    public class OrganizationService
    {
        private readonly IOrganizationRepository _iOrganizationRepository;

        public OrganizationService(IOrganizationRepository iOrganizationRepository)
        {
            _iOrganizationRepository = iOrganizationRepository;
        }

        public Organization GetOrganizationById(int id)
        {
            try
            {
                var organizationEntities = _iOrganizationRepository.GetByid(id);
                return organizationEntities?.ToBLL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateOrganization(Organization organization)
        {
            try
            {
                var organizationEntity = organization.ToDAL();
                _iOrganizationRepository.Add(organizationEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteOrganization(int id)
        {
            try
            {
                _iOrganizationRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
