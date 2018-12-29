using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    /// <summary>
    /// 管理员显示菜单
    /// </summary>
    public class Menu
    {
        public int ID { get; set; }

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
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 子级菜单列表
        /// </summary>
        public ICollection<Menu> ChildMenu { get; set; }
    }
}
