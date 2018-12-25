using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    /// <summary>
    /// 登录信息接受类
    /// author:leoxuan
    /// date:2018年12月25日 15:53:27
    /// </summary>
    public class LoginManager
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 是否记住用户
        /// </summary>
        public string Signup { get; set; }
    }
}
