namespace Prey.Models
{
    /// <summary>
    /// 设备附加信息
    /// </summary>
    public abstract class DeviceAttachBase : EntityBase
    {
        /// <summary>
        /// Gets or sets 设备ID
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// Gets or sets 设备
        /// </summary>
        public DeviceBase Device { get; set; }
    }
}
