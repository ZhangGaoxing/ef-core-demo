using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Pandemic.Models
{
    /// <summary>
    /// 医生
    /// </summary>
    [Description("医生")]
    [Table("doctor")]
    public class Doctor
    {
        /// <summary>
        /// 医生ID
        /// </summary>
        [Description("医生ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        [Description("医生姓名")]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 所属医院ID
        /// </summary>
        [Description("所属医院ID")]
        [Column("hospital_id")]
        public int HospitalId { get; set; }

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

        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }

        public virtual List<Report> Reports { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
