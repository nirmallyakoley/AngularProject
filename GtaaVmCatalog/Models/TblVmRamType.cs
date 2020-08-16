using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VM_RAM_Type")]
    public partial class TblVmRamType
    {
        public TblVmRamType()
        {
            TblVmRequisitionDetails = new HashSet<TblVmRequisitionDetails>();
        }

        [Key]
        [Column("VMRAMID")]
        [StringLength(100)]
        public string Vmramid { get; set; }
        [Column("VMRAMType")]
        [StringLength(10)]
        public string Vmramtype { get; set; }

        [InverseProperty("Vmram")]
        public virtual ICollection<TblVmRequisitionDetails> TblVmRequisitionDetails { get; set; }
    }
}
