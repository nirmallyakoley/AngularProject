using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VM_RequisitionDetails")]
    public partial class TblVmRequisitionDetails
    {
        [Column("RequestID")]
        public int RequestId { get; set; }
        [Key]
        [Column("VMRequisitionID")]
        public int VmrequisitionId { get; set; }
        [Required]
        [Column("VMEnvironmentTypeID")]
        [StringLength(100)]
        public string VmenvironmentTypeId { get; set; }
        [Required]
        [Column("VMOSTypeID")]
        [StringLength(100)]
        public string VmostypeId { get; set; }
        [Required]
        [Column("VMCPUID")]
        [StringLength(100)]
        public string Vmcpuid { get; set; }
        [Required]
        [Column("VMRAMID")]
        [StringLength(100)]
        public string Vmramid { get; set; }
        [Required]
        [Column("VMSTORID")]
        [StringLength(100)]
        public string Vmstorid { get; set; }
        [Column("VMMonitoringID")]
        [StringLength(100)]
        public string VmmonitoringId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LoggedTime { get; set; }

        [ForeignKey(nameof(Vmcpuid))]
        [InverseProperty(nameof(TblVmCpuType.TblVmRequisitionDetails))]
        public virtual TblVmCpuType Vmcpu { get; set; }
        [ForeignKey(nameof(VmenvironmentTypeId))]
        [InverseProperty(nameof(TblVmEnvironmentType.TblVmRequisitionDetails))]
        public virtual TblVmEnvironmentType VmenvironmentType { get; set; }
        [ForeignKey(nameof(VmostypeId))]
        [InverseProperty(nameof(TblVmOsType.TblVmRequisitionDetails))]
        public virtual TblVmOsType Vmostype { get; set; }
        [ForeignKey(nameof(Vmramid))]
        [InverseProperty(nameof(TblVmRamType.TblVmRequisitionDetails))]
        public virtual TblVmRamType Vmram { get; set; }
        [ForeignKey(nameof(Vmstorid))]
        [InverseProperty(nameof(TblVmStorageType.TblVmRequisitionDetails))]
        public virtual TblVmStorageType Vmstor { get; set; }
    }
}
