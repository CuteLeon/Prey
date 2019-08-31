using System.ComponentModel;
using Prey.Common;

namespace Prey.Models
{
    /// <summary>
    /// 手机
    /// </summary>
    public class Phone : Moilble
    {
        /// <summary>
        /// Gets or sets 手机号码
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string PhoneNumber { get; set; }
    }
}
