using System.ComponentModel.DataAnnotations;

namespace Prey.Models
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public class UploadFile : DeviceAttachBase
    {
        /// <summary>
        /// Gets or sets 源路径
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "上传文件源路径不允许为空")]
        public string SourcePath { get; set; }

        /// <summary>
        /// Gets or sets 目标路径
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "上传文件目标路径不允许为空")]
        public string TargetPath { get; set; }
    }
}
