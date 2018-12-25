using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities.Manager;
using UniversalForm.Domain.IRepositories;

namespace UniversalForm.EF.Repositories
{
    /// <summary>
    /// author:leoxuan
    /// data:2018年12月25日 14:15:21
    /// </summary>
    public class ManagerRepository : RepositoryBase<T_Manager, int>, IManagerRepository
    {
        public ManagerRepository(EFDBContext dbcontext) : base(dbcontext)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPwd"></param>
        /// <returns></returns>
        public T_Manager Login(string LoginName, string LoginPwd)
        {
            if (LoginName!="" && LoginPwd!="")
            {
                return FirstOrDefault(p => p.LoginName.Equals(LoginName) && p.LoginPwd.Equals(LoginPwd));
            }
            else
            {
                return null;
            }            
        }
    }
}
