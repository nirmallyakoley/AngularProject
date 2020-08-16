using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VM_Monitoring_Type")]
    public partial class TblVmMonitoringType
    {
        [Key]
        [Column("VMMonitoringID")]
        [StringLength(100)]
        public string VmmonitoringId { get; set; }
        [Column("VMMonitoringType")]
        [StringLength(500)]
        public string VmmonitoringType { get; set; }
        [Column("VMMonitoringRate", TypeName = "decimal(18, 2)")]
        public decimal? VmmonitoringRate { get; set; }
    }
}
