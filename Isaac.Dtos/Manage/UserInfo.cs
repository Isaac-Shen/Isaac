using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Dtos.Manage
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户密码密文
        /// </summary>
        public string PasswordCrypto { get; set; }

        /// <summary>
        /// 用户角色编号
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        public string Description { get; set; }
    }
}
