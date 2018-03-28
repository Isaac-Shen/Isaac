using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Models.Authorization
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public class Sys_Actions
    {
        /// <summary>
        /// 功能编号
        /// </summary>
        public int IID { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 功能状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 功能链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 功能描述
        /// </summary>
        public string Description { get; set; }
    }
}
