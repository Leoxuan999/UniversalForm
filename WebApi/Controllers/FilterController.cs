using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Controllers
{
    /// <summary>
    /// 控制器事件过滤
    /// </summary>
    public class FilterController : Controller
    {
        /// <summary>
        /// 登录过滤
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //验证登录状态
            if (HttpContext.Session.GetString("NickName") == null)
            {
                //重定向到登录页面
                HttpContext.Response.Redirect("/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }        
    }
}