using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_Miscallenous_Rate")]
    public partial class TblMiscallenousRate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Cost_Type")]
        [StringLength(100)]
        public string CostType { get; set; }
        [Column("Cost_Detail")]
        [StringLength(1000)]
        public string CostDetail { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Rate { get; set; }
    }
}
