using System;
using System.Collections.Generic;
using System.Text;
using UniversalForm.Domain.Entities;
using UniversalForm.Domain.IRepositories;
using System.Linq;
using System.Linq.Expressions;

namespace UniversalForm.EF.Repositories
{
    public class FormRepository : RepositoryBase<T_Form, int>,IFormRepository
    {
        public FormRepository(EFDBContext dbcontext) : base(dbcontext)
        {

        }

        /// <summary>
        /// 验证相同名称的活动是否存在
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public bool Exists(string formName)
        {
            var t_form = _dbcontext.Set<T_Form>().Where(p => p.FormName.Equals(formName)).FirstOrDefault();
            if (t_form!=null)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
