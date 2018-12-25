using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities.Manager;
using UniversalForm.Domain.IRepositories;

namespace UniversalForm.EF.Repositories
{
    /// <summary>
    /// author:leoxuan
    /// data:2018年12月25日
    /// </summary>
    public class RolePermissionRepository : RepositoryBase<T_RolePermission, int>, IRolePermissionRepository
    {
        public RolePermissionRepository(EFDBContext dbcontext) : base(dbcontext)
        {
        }
    }
}
