using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VM_Environment_Type")]
    public partial class TblVmEnvironmentType
    {
        public TblVmEnvironmentType()
        {
            TblVmRequisitionDetails = new HashSet<TblVmRequisitionDetails>();
        }

        [Key]
        [Column("VMEnvironmentTypeID")]
        [StringLength(100)]
        public string VmenvironmentTypeId { get; set; }
        [Column("VMEnvironment")]
        [StringLength(1000)]
        public string Vmenvironment { get; set; }

        [InverseProperty("VmenvironmentType")]
        public virtual ICollection<TblVmRequisitionDetails> TblVmRequisitionDetails { get; set; }
    }
}
