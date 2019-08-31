using System.ComponentModel;
using Prey.Common;

namespace Prey.Models
{
    /// <summary>
    /// 位置
    /// </summary>
    public class Location : DeviceAttachBase
    {
        /// <summary>
        /// Gets or sets 经度
        /// </summary>
        [DefaultValue(DefaultValues.UnknownDouble)]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets 纬度
        /// </summary>
        [DefaultValue(DefaultValues.UnknownDouble)]
        public double Latitude { get; set; }
    }
}
