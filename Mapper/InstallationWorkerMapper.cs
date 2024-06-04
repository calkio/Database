using Database.BLL.Entity;
using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Mapper
{
    internal static class InstallationWorkerMapper
    {
        public static InstallationWorker ToBLL(this InstallationWorkerDAL entity)
        {
            return new InstallationWorker(
                    id: entity.Id,
                    idInstallation: entity.IdInstallation,
                    idWorker: entity.IdWorker
                );
        }

        public static InstallationWorkerDAL ToDAL(this InstallationWorker model)
        {
            return new InstallationWorkerDAL
            {
                Id = model.Id,
                IdInstallation = model.IdInstallation,
                IdWorker = model.IdWorker
            };
        }
    }
}
