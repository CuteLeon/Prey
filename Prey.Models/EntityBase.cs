using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Prey.Common;

namespace Prey.Models
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets 设备ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "实体 ID 不允许为空")]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets 设备名称
        /// </summary>
        [DefaultValue(DefaultValues.UnknownString)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
