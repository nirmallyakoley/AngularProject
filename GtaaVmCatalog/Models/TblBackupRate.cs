using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_BACKUP_Rate")]
    public partial class TblBackupRate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("BACKUP_Environment")]
        [StringLength(100)]
        public string BackupEnvironment { get; set; }
        [Column("BACKUP_Rate_Per_GB", TypeName = "decimal(18, 2)")]
        public decimal? BackupRatePerGb { get; set; }
    }
}
