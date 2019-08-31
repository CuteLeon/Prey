using System.Collections.Generic;
using System.ComponentModel;
using Prey.Common;

namespace Prey.Models
{
    /// <summary>
    /// 人员
    /// </summary>
    public class Person : EntityBase
    {
        /// <summary>
        /// Gets or sets 地址
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets 备注
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets 手机
        /// </summary>
        public virtual List<Phone> Phones { get; set; } = new List<Phone>();

        /// <summary>
        /// Gets or sets 桌面电脑
        /// </summary>
        public virtual List<DesktopComputer> DesktopComputers { get; set; } = new List<DesktopComputer>();

        /// <summary>
        /// Gets or sets 笔记本电脑
        /// </summary>
        public virtual List<LaptopComputer> LaptopComputers { get; set; } = new List<LaptopComputer>();
    }
}
