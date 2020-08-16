using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_CPU_Rate")]
    public partial class TblCpuRate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CPU_Environment")]
        [StringLength(100)]
        public string CpuEnvironment { get; set; }
        [Column("CPU_Rate_Per_Unit", TypeName = "decimal(18, 2)")]
        public decimal? CpuRatePerUnit { get; set; }
    }
}
