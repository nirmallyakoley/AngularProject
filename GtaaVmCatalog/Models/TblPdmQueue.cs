using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_PDM_Queue")]
    public partial class TblPdmQueue
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("RequestID")]
        public int RequestId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
    }
}
