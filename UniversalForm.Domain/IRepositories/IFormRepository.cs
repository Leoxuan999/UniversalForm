using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities;

namespace UniversalForm.Domain.IRepositories
{
    public interface IFormRepository : IRepository<T_Form,int>
    {
        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Exists(string fromName);
    }
}
