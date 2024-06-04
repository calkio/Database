using Database.BLL.Entity;
using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Mapper
{
    internal static class InstallationMapper
    {
        public static Installation ToBLL(this InstallationDAL entity)
        {
            return new Installation(
                    id: entity.Id,
                    date: entity.Date,
                    idOrganization: entity.IdOrganization
                );
        }

        public static InstallationDAL ToDAL(this Installation model)
        {
            return new InstallationDAL
            {
                Id = model.Id,
                Date = model.Date,
                IdOrganization = model.IdOrganization
            };
        }
    }
}
