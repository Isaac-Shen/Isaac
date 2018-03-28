using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Models.Authorization
{
    /// <summary>
    /// 系统角色
    /// </summary>
    public class Sys_Roles
    {
        /// <summary>
        /// 角色变化
        /// </summary>
        public int IID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 角色状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }
    }
}
