using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalForm.Domain.Entities.Manager
{
    /// <summary>
    /// 管理员角色表
    /// author:leoxuan
    /// data:2018年12月24日 15:56:22
    /// </summary>
    public class T_Manager_Role : Entity<int>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色类型
        /// 1 超管（不可删除）
        /// 2 管理员
        /// </summary>
        public int RoleType { get; set; }

        /// <summary>
        /// 是否系统默认
        /// 0 否
        /// 1 是
        /// </summary>
        public int IsSystem { get; set; }

        /// <summary>
        /// 添加人ID
        /// </summary>
        public int AddManagerId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 修改人ID
        /// </summary>
        public int? ModifyManagerId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 是否删除
        /// 0 否
        /// 1 是
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
