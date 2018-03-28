using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Models.Authorization
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class Sys_Users
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public int IID { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 用户角色群
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        public string Description { get; set; }
    }
}
