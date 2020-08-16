using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VM_OS_Type")]
    public partial class TblVmOsType
    {
        public TblVmOsType()
        {
            TblVmRequisitionDetails = new HashSet<TblVmRequisitionDetails>();
        }

        [Key]
        [Column("VMOSTypeID")]
        [StringLength(100)]
        public string VmostypeId { get; set; }
        [Column("VMOS")]
        [StringLength(1000)]
        public string Vmos { get; set; }

        [InverseProperty("Vmostype")]
        public virtual ICollection<TblVmRequisitionDetails> TblVmRequisitionDetails { get; set; }
    }
}
