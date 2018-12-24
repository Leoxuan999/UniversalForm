using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversalForm.Domain.Entities.Manager
{
    /// <summary>
    /// 角色权限表
    /// author：leoxuan
    /// data:2018年12月24日 16:03:32
    /// </summary>
    public class T_RolePermission : Entity<int>
    {
        [NotMapped]
        public virtual T_Manager_Role T_Manager_Role { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoldId { get; set; }

        [NotMapped]
        public virtual T_Menu T_Menu { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 操作类型，功能权限
        /// </summary>
        public string Permission { get; set; }

    }
}
