using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Comm.Enumrations
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 冗余
        /// </summary>
        Verbose = 1,

        /// <summary>
        /// 跟踪
        /// </summary>
        Trace = 2,

        /// <summary>
        /// 调试
        /// </summary>
        Debug = 3,

        /// <summary>
        /// 信息
        /// </summary>
        Information = 4,

        /// <summary>
        /// 警告
        /// </summary>
        Warning = 5,

        /// <summary>
        /// 错误
        /// </summary>
        Error = 6,

        /// <summary>
        /// 致命
        /// </summary>
        Fatal = 7,

        /// <summary>
        /// 全部
        /// </summary>
        All = 1,

        /// <summary>
        /// 关闭
        /// </summary>
        Off = 7,

        /// <summary>
        /// 无日志
        /// </summary>
        None = 7
    }
}
