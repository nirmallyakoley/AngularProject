using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_STORAGE_Rate")]
    public partial class TblStorageRate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("STOR_Environment")]
        [StringLength(100)]
        public string StorEnvironment { get; set; }
        [Column("STOR_Rate_Per_GB", TypeName = "decimal(18, 2)")]
        public decimal? StorRatePerGb { get; set; }
    }
}
