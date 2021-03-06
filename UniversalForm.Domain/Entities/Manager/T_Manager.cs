﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalForm.Domain.Entities.Manager
{
    /// <summary>
    /// 管理员表
    /// author:leoxuan
    /// data:2018年12月24日 16:50:15
    /// </summary>
    public class T_Manager : Entity<int>
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>        
        public string LoginPwd { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
		/// 用户昵称
		/// </summary>
		public String NickName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LoginCount { get; set; }

        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        public String LastLoginIP { get; set; }

        /// <summary>
		/// 最后一次登录时间
		/// </summary>
		public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 是否锁定
        /// 0 否
        /// 1 是
        /// </summary>
        public int IsLock { get; set; }

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
