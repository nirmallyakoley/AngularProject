using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VMDocument")]
    public partial class TblVmdocument
    {
        [Column("RequestID")]
        public int RequestId { get; set; }
        [Key]
        [Column("DocumentID")]
        public int DocumentId { get; set; }
        [Column("DocumentURL")]
        [StringLength(1000)]
        public string DocumentUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LoggedTime { get; set; }

        [ForeignKey(nameof(RequestId))]
        [InverseProperty(nameof(TblVmproject.TblVmdocument))]
        public virtual TblVmproject Request { get; set; }
    }
}
