using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_RAM_Rate")]
    public partial class TblRamRate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("RAM_Environment")]
        [StringLength(100)]
        public string RamEnvironment { get; set; }
        [Column("RAM_Rate_Per_Unit", TypeName = "decimal(18, 2)")]
        public decimal RamRatePerUnit { get; set; }
    }
}
