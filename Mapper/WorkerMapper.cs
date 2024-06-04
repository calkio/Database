using Database.BLL.Entity;
using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Mapper
{
    internal static class WorkerMapper
    {
        public static Worker ToBLL(this WorkerDAL entity)
        {
            return new Worker(
                    id: entity.Id,
                    lastName: entity.LastName,
                    firstName: entity.FirstName,
                    middleName: entity.MiddleName
                );
        }

        public static WorkerDAL ToDAL(this Worker model)
        {
            return new WorkerDAL
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName
            };
        }
    }
}
