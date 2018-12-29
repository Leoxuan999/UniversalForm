using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversalForm.Domain.IRepositories;

namespace WebApi.Controllers
{
    public class HomeController : FilterController
    {

        private readonly IManagerRepository _manager;
        private readonly IManagerRoleRepository _managerRole;
        private readonly IMenuRepository _menu;
        private readonly IRolePermissionRepository _rolePermission;

        public HomeController(IManagerRepository manager, IManagerRoleRepository managerRole, IMenuRepository menu, IRolePermissionRepository rolePermission)
        {
            _manager = manager;
            _managerRole = managerRole;
            _menu = menu;
            _rolePermission = rolePermission;
        }
        public IActionResult Index()
        {
            return Redirect("~/Form");
        }

        /// <summary>
        /// 获取用户菜单权限
        /// </summary>
        /// <returns></returns>
        public IActionResult GetMenu()
        {
            if (HttpContext.Session.GetInt32("ManagerRole") == null)
            {
                return Redirect("~/Login");
                return Json("获取用户菜单权限失败，未获取到用户角色");

            }

            //获取角色菜单权限的集合
            var rolePermissions = _rolePermission.GetAllList(p => p.RoleId == HttpContext.Session.GetInt32("ManagerRole"));

            //获取菜单Id列表
            var menuIds = rolePermissions.Select(p => p.MenuId).ToList();

            //获取菜单列表
            var menus = _menu.GetAllList(p => menuIds.Contains(p.ID));

            StringBuilder sb = new StringBuilder();
            sb.Append("");

            return Json(menus);
        }
    }
}