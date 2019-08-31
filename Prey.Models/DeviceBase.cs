using System.Collections.Generic;
using System.ComponentModel;
using Prey.Common;

namespace Prey.Models
{
    /// <summary>
    /// 设备基类
    /// </summary>
    public abstract class DeviceBase : EntityBase
    {
        /// <summary>
        /// Gets or sets 型号
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets 拥有者ID
        /// </summary>
        public string OwnerID { get; set; }

        /// <summary>
        /// Gets or sets 拥有者
        /// </summary>
        public Person Owner { get; set; }

        /// <summary>
        /// Gets or sets 位置
        /// </summary>
        public virtual List<Location> Locations { get; set; } = new List<Location>();

        /// <summary>
        /// Gets or sets 联系人
        /// </summary>
        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Gets or sets 上传文件
        /// </summary>
        public virtual List<UploadFile> UploadFiles { get; set; } = new List<UploadFile>();
    }
}
