using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalForm.Domain.Entities.Manager
{
    /// <summary>
    /// 菜单表
    /// author：leoxuan
    /// data:2018年12月24日 16:06:53
    /// </summary>
    public class T_Menu : Entity<int>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public int FatherId { get; set; }

        /// <summary>
        /// 图标地址
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 操作类型，按钮功能权限使用
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
		/// 是否显示
        /// 0 否
        /// 1 是
		/// </summary>		
        public int IsDisplay { get; set; }

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
