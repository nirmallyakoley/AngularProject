using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_OPEX_Cost_Detail")]
    public partial class TblOpexCostDetail
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("RequestID")]
        public int? RequestId { get; set; }
        [Column("VMRequisitionID")]
        public int? VmrequisitionId { get; set; }
        [StringLength(1000)]
        public string OpexType { get; set; }
        public int? Year { get; set; }
        public int? Months { get; set; }
        [Column("Cost_Per_Year", TypeName = "decimal(18, 2)")]
        public decimal? CostPerYear { get; set; }
        [Column("Actual_Cost", TypeName = "decimal(18, 2)")]
        public decimal? ActualCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
    }
}
