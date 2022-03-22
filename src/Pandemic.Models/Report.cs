using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Pandemic.Models
{
    /// <summary>
    /// 检测报告
    /// </summary>
    [Description("检测报告")]
    [Table("report")]
    public class Report
    {
        /// <summary>
        /// 检测报告ID
        /// </summary>
        [Description("检测报告ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 检测报告类型ID
        /// </summary>
        [Description("检测报告类型ID")]
        [Column("report_type_cd")]
        public string ReportTypeCd { get; set; }

        /// <summary>
        /// 医生ID
        /// </summary>
        [Description("医生ID")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        /// <summary>
        /// 病人ID
        /// </summary>
        [Description("病人ID")]
        [Column("patient_id")]
        public int PatientId { get; set; }

        /// <summary>
        /// 检测结果
        /// </summary>
        [Description("检测结果")]
        [Column("result")]
        public bool Result { get; set; } = false;

        /// <summary>
        /// 检测样本收集时间
        /// </summary>
        [Description("检测样本收集时间")]
        [Column("collect_time")]
        public DateTime? CollectTime { get; set; }

        /// <summary>
        /// 检测时间
        /// </summary>
        [Description("检测时间")]
        [Column("test_time")]
        public DateTime? TestTime { get; set; }

        /// <summary>
        /// 报告生成时间
        /// </summary>
        [Description("报告生成时间")]
        [Column("report_time")]
        public DateTime? ReportTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        [Column("description")]
        public string Description { get; set; }

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

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("ReportTypeCd")]
        public virtual ReportType ReportType { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
