using Database.DAL;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository.Interface
{
    public interface IInstallationWorkerRepository
    {
        public Task AddAsync(InstallationDAL installationDAL, WorkerDAL workerDAL);
        public Task DeleteAsync(int id);
    }
}
