using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities.Manager;

namespace UniversalForm.Domain.IRepositories
{
    public interface IManagerRepository : IRepository<T_Manager,int>
    {
        T_Manager Login(string LoginName, string LoginPwd);
    }
}
