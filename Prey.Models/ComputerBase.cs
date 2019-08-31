using System.ComponentModel;
using Prey.Common;

namespace Prey.Models
{
    /// <summary>
    /// 电脑基类
    /// </summary>
    public class ComputerBase : DeviceBase
    {
        /// <summary>
        /// Gets or sets 处理器
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string CPU { get; set; }

        /// <summary>
        /// Gets or sets 显卡
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string GPU { get; set; }

        /// <summary>
        /// Gets or sets 内存
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string Memory { get; set; }

        /// <summary>
        /// Gets or sets 硬盘
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string Disk { get; set; }

        /// <summary>
        /// Gets or sets mAC 地址
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string MAC { get; set; }
    }
}
