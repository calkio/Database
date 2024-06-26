﻿using Database.DAL;
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
        public Task<OrganizationDAL> GetByIdAsync(int id);
        public Task AddAsync(OrganizationDAL organizationDAL);
        public Task DeleteAsync(int id);
    }
}
