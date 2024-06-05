using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository.Interface
{
    public interface IInstallationRepository
    {
        public Task<InstallationDAL> GetByIdAsync(int id);
        public Task AddAsync(InstallationDAL installationDAL);
        public Task DeleteAsync(int id);
    }
}
