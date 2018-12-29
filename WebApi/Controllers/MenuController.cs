using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversalForm.Domain.IRepositories;
using WebApi.Model;
using AutoMapper;
using UniversalForm.Domain.Entities.Manager;

namespace WebApi.Controllers
{
    public class MenuController : FilterController
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository repository)
        {
            _menuRepository = repository;
        }


        public IActionResult Index()
        {
            List<T_Menu> farthermenu = _menuRepository.GetAllList(p => p.FatherId == 0);
            List<Menu> menu = Mapper.Map<List<Menu>>(farthermenu);
            foreach (var item in menu)
            {
                item.ChildMenu = Mapper.Map<List<Menu>>(_menuRepository.GetAllList(p => p.FatherId==item.ID));
            }
            return View(menu);
        }
    }
}