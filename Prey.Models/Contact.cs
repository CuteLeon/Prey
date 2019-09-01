using System.ComponentModel;
using Prey.Common;

namespace Prey.Models
{
    /// <summary>
    /// 联系人
    /// </summary>
    public class Contact : DeviceAttachBase
    {
        /// <summary>
        /// Gets or sets 号码
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string Number { get; set; }
    }
}
