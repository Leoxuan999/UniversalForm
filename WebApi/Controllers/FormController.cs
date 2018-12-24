using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversalForm.Domain.IRepositories;

namespace WebApi.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormRepository _form;

        public FormController(IFormRepository form)
        {
            _form = form;
        }

        public IActionResult Index()
        {
            int rowCount;
            var list = _form.LoadPageList(1, 10, out rowCount, null,null);
            return View(list);
        }


    }
}