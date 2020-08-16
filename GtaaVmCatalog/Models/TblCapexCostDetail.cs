using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_CAPEX_Cost_Detail")]
    public partial class TblCapexCostDetail
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("RequestID")]
        public int RequestId { get; set; }
        [Column("VMRequisitionID")]
        public int VmrequisitionId { get; set; }
        [Column("VMEnvironmentTypeID")]
        [StringLength(100)]
        public string VmenvironmentTypeId { get; set; }
        [Column("Capex_Type")]
        [StringLength(100)]
        public string CapexType { get; set; }
        [Column("Capex_Unit")]
        public int? CapexUnit { get; set; }
        [Column("Capex_Per_Unit_Cost", TypeName = "decimal(18, 2)")]
        public decimal? CapexPerUnitCost { get; set; }
        [Column("Capex_Cost", TypeName = "decimal(29, 2)")]
        public decimal? CapexCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
    }
}
