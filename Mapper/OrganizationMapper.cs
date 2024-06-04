using Database.BLL.Entity;
using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Mapper
{
    internal static class OrganizationMapper
    {
        public static Organization ToBLL(this OrganizationDAL entity)
        {
            return new Organization(
                    id: entity.Id,
                    name: entity.Name,
                    numberOfSetups: entity.NumberOfSetups
                );
        }

        public static OrganizationDAL ToDAL(this Organization model)
        {
            return new OrganizationDAL
            {
                Id = model.Id,
                Name = model.Name,
                NumberOfSetups = model.NumberOfSetups
            };
        }
    }
}
