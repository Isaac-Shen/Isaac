using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Models.Authorization
{
    /// <summary>
    /// 角色功能配置
    /// </summary>
    public class Sys_RoleConfig
    {
        /// <summary>
        /// 配置编号
        /// </summary>
        public int IID { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 功能编号
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// 配置状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 配置描述
        /// </summary>
        public string Description { get; set; }
    }
}
