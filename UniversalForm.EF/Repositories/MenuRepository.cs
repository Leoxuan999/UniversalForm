using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities.Manager;
using UniversalForm.Domain.IRepositories;

namespace UniversalForm.EF.Repositories
{
    /// <summary>
    /// author:leoxuan
    /// data：2018年12月25日 14:16:40
    /// </summary>
    public class MenuRepository : RepositoryBase<T_Menu, int>, IMenuRepository
    {
        public MenuRepository(EFDBContext dbcontext) : base(dbcontext)
        {
        }
    }
}
