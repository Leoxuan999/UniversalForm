using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities.Manager;
using UniversalForm.Domain.IRepositories;

namespace UniversalForm.EF.Repositories
{
    /// <summary>
    /// author:leoxuan
    /// data:2018年12月25日 14:21:04
    /// </summary>
    public class ManagerRoleRepository : RepositoryBase<T_Manager_Role, int>, IManagerRoleRepository
    {
        public ManagerRoleRepository(EFDBContext dbcontext) : base(dbcontext)
        {
        }
    }
}
