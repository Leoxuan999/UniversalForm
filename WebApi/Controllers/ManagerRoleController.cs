using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversalForm.Domain.IRepositories;

namespace WebApi.Controllers
{
    public class ManagerRoleController : FilterController
    {
        private readonly IManagerRoleRepository _managerRole;

        public ManagerRoleController(IManagerRoleRepository managerRole)
        {
            _managerRole = managerRole;
        }

        public IActionResult Index()
        {
            var rolelist = _managerRole.GetAllList();

            return View(rolelist);
        }
    }
}