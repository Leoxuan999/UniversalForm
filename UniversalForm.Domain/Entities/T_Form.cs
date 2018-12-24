using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace UniversalForm.Domain.Entities
{
    /// <summary>
    /// 活动表
    /// author：宣爱军
    /// date:2018年12月17日 16:45:00
    /// </summary>
    public class T_Form : Entity<int>
    {
        /// <summary>
        /// 表单名称
        /// </summary>
        [Display(Name = "活动表单名称")]
        public string FormName { get; set; }

        /// <summary>
        /// 表单说明
        /// </summary>
        [Display(Name = "表单说明")]
        public string Exception { get; set; }

        /// <summary>
        /// 头图
        /// </summary>
        [Display(Name = "头图")]
        public string TopImg { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 是否需要支付
        /// 0 是
        /// 1 否
        /// </summary>
        [Display(Name = "是否需要支付")]
        public int NeedPay { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        [Display(Name = "支付金额")]
        public double PayPrice { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public string AddDate { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display(Name = "最后修改时间")]
        public string EditDate { get; set; }

        /// <summary>
        /// 分享图片
        /// </summary>
        [Display(Name = "分享图片")]
        public string ShareImg { get; set; }

        /// <summary>
        /// 分享地址
        /// </summary>
        [Display(Name = "分享地址")]
        public string ShareUrl { get; set; }

        /// <summary>
        /// 分享标题
        /// </summary>
        [Display(Name = "分享标题")]
        public string ShareTitle { get; set; }

        /// <summary>
        /// 分享说明
        /// </summary>
        [Display(Name = "分享说明")]
        public string ShareExp { get; set; }

        /// <summary>
        /// 免责条款
        /// </summary>
        [Display(Name = "免责条款")]
        public string MianZe { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        [Display(Name = "活动开始时间")]
        public string StartDate { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        [Display(Name = "活动结束时间")]
        public string EndDate { get; set; }

        /// <summary>
        /// 每个微信限制提交一次
        /// 0是
        /// 1否 
        /// </summary>
        [Display(Name = "每个微信限制提交一次")]
        public int SubCheck { get; set; }

        /// <summary>
        /// 结束报名数量 
        /// 默认值0 不限制
        /// </summary>
        [Display(Name = "结束报名数量")]
        public int EndNumber { get; set; }

        /// <summary>
        /// 表单状态
        /// 0 正在进行
        /// 1 未开始
        /// 2 已结束
        /// </summary>
        [Display(Name = "表单状态")]
        public int State { get; set; }

        /// <summary>
        /// 报名结束跳转链接
        /// </summary>
        [Display(Name = "报名结束跳转链接")]
        public string JumpUrl { get; set; }

        /// <summary>
        /// 管理员Id
        /// </summary>
        [Display(Name = "管理员Id")]
        public int MId { get; set; }
    }
}