using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VMApprovalRejection")]
    public partial class TblVmapprovalRejection
    {
        [Column("RequestID")]
        public int RequestId { get; set; }
        [Key]
        [Column("ApprovalRejectionID")]
        public int ApprovalRejectionId { get; set; }
        [StringLength(1000)]
        public string ApprovalLevel { get; set; }
        [StringLength(1000)]
        public string ApprovedOrRejectedBy { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ApprovedOrRejectedOn { get; set; }

        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(TblVmproject.TblVmapprovalRejection))]
        public virtual TblVmproject Request { get; set; }
    }
}
