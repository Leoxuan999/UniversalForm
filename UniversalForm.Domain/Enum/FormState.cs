using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalForm.Domain.Enum
{
    public enum FormState
    {
        /// <summary>
        /// 正在进行
        /// </summary>
        start=0,
        /// <summary>
        /// 未开始
        /// </summary>
        ready =1,
        /// <summary>
        /// 结束
        /// </summary>
        end =2
    }
}
