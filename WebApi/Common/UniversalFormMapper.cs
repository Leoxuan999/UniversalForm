using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalForm.Domain.Entities.Manager;
using WebApi.Model;

namespace WebApi.Common
{
    public class UniversalFormMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<T_Menu, Menu>();
            }
            );
        }
    }
}
