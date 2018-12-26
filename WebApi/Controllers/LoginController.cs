﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversalForm.Domain.IRepositories;
using WebApi.Model;

namespace WebApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IManagerRepository _manager;
        private readonly IManagerRoleRepository _managerRole;
        private readonly IMenuRepository _menu;
        private readonly IRolePermissionRepository _rolePermission;

        public LoginController(IManagerRepository manager,IManagerRoleRepository managerRole,IMenuRepository menu,IRolePermissionRepository rolePermission)
        {
            _manager = manager;
            _managerRole = managerRole;
            _menu = menu;
            _rolePermission = rolePermission;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录验证
        /// author:leoxuan
        /// data:2018年12月25日 16:00:47
        /// </summary>
        /// <param name="login">登录信息接受类</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginManager login)
        {
            var manager = _manager.Login(login.UserName, login.UserPwd);
            if (manager!=null)
            {
                manager.LoginCount += 1;
                manager.LastLoginTime = DateTime.Now;
                manager.LastLoginIP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                HttpContext.Session.SetInt32("ManagerRole", manager.RoleId);
                return Redirect("~/Home");
            }
            return View("用户名或密码错误");
        }

        /// <summary>
        /// 获取用户菜单权限
        /// </summary>
        /// <returns></returns>
        public IActionResult GetMenu()
        {
            if (HttpContext.Session.GetInt32("ManagerRole")==null)
            {
                return Json("获取用户菜单权限失败，未获取到用户角色");
            }

            //获取角色菜单权限的集合
            var rolePermissions = _rolePermission.GetAllList(p => p.RoleId == HttpContext.Session.GetInt32("ManagerRole"));

            //获取菜单Id列表
            var menuIds = rolePermissions.Select(p => p.MenuId).ToList();

            //获取菜单列表
            var menus = _menu.GetAllList(p => menuIds.Contains(p.ID));



            return Json(menus);
        }
    }
}