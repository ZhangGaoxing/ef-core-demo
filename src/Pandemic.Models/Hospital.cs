using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Pandemic.Models
{
    /// <summary>
    /// 医院
    /// </summary>
    [Description("医院")]
    [Table("hospital")]
    public class Hospital
    {
        /// <summary>
        /// 医院ID
        /// </summary>
        [Description("医院ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [Description("医院名称")]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [Description("删除标记")]
        [Column("is_deleted")]
        public int IsDeleted { get; set; } = 0;

        /// <summary>
        /// 创建者ID
        /// </summary>
        [Description("创建者ID")]
        [Column("creator_id")]
        public string CreatorId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [Column("created_dt")]
        public DateTime CreatedDt { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改者ID
        /// </summary>
        [Description("修改者ID")]
        [Column("modifier_id")]
        public string ModifierId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Description("修改时间")]
        [Column("modified_dt")]
        public DateTime ModifiedDt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
