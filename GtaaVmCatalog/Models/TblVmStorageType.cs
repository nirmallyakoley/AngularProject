using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VM_Storage_Type")]
    public partial class TblVmStorageType
    {
        public TblVmStorageType()
        {
            TblVmRequisitionDetails = new HashSet<TblVmRequisitionDetails>();
        }

        [Key]
        [Column("VMSTORID")]
        [StringLength(100)]
        public string Vmstorid { get; set; }
        [Column("VMStorageType")]
        [StringLength(10)]
        public string VmstorageType { get; set; }
        [Column("VMStorageType_GB")]
        public long? VmstorageTypeGb { get; set; }

        [InverseProperty("Vmstor")]
        public virtual ICollection<TblVmRequisitionDetails> TblVmRequisitionDetails { get; set; }
    }
}
