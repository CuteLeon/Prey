using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prey.Models
{
    /// <summary>
    /// 设备基类.
    /// </summary>
    public abstract class DeviceBase
    {
        /// <summary>
        /// Gets or sets 设备ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "设备 ID 不允许为空")]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets 设备名称
        /// </summary>
        [DefaultValue("未命名设备")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "设备名称不允许为空")]
        public string Name { get; set; }
    }
}
