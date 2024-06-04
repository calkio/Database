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
        public InstallationDAL GetByid(int id);
        public void Add(InstallationDAL installationDAL);
        public void Delete(int id);
    }
}
