using Database.DAL;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository.Interface
{
    public interface IOrganizationRepository
    {
        public OrganizationDAL GetByid(int id);
        public void Add(OrganizationDAL organizationDAL);
        public void Delete(int id);
    }
}
