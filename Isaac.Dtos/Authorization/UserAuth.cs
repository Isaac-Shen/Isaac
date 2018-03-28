using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Dtos
{
    /// <summary>
    /// 用户授权
    /// </summary>
    public class UserAuth
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId;

        /// <summary>
        /// 用户权限
        /// </summary>
        public List<string> Actions;
    }
}
