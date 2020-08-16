using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VM_CPU_Type")]
    public partial class TblVmCpuType
    {
        public TblVmCpuType()
        {
            TblVmRequisitionDetails = new HashSet<TblVmRequisitionDetails>();
        }

        [Key]
        [Column("VMCPUID")]
        [StringLength(100)]
        public string Vmcpuid { get; set; }
        [Required]
        [Column("VMCPUType")]
        [StringLength(100)]
        public string Vmcputype { get; set; }

        [InverseProperty("Vmcpu")]
        public virtual ICollection<TblVmRequisitionDetails> TblVmRequisitionDetails { get; set; }
    }
}
