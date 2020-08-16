using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GtaaVmCatalog.Models
{
    [Table("tbl_VMProject")]
    public partial class TblVmproject
    {
        public TblVmproject()
        {
            TblVmapprovalRejection = new HashSet<TblVmapprovalRejection>();
            TblVmdocument = new HashSet<TblVmdocument>();
        }

        [Key]
        [Column("RequestID")]
        public int RequestId { get; set; }
        [StringLength(1000)]
        public string ProjectName { get; set; }
        [StringLength(1000)]
        public string ProjectNumber { get; set; }
        [StringLength(1000)]
        public string RequesterName { get; set; }
        [StringLength(1000)]
        public string ArchitectName { get; set; }
        [Column("PDMName")]
        [StringLength(1000)]
        public string Pdmname { get; set; }
        [Column("QuoteIDNumber")]
        [StringLength(1000)]
        public string QuoteIdnumber { get; set; }
        [StringLength(1000)]
        public string ChangeOrderNumber { get; set; }
        [StringLength(1000)]
        public string AgreementNumber { get; set; }
        [StringLength(1000)]
        public string ReleaseNumber { get; set; }
        [StringLength(1000)]
        public string ChangeRequestNumber { get; set; }
        [StringLength(1000)]
        public string BriefDescription { get; set; }
        [Required]
        [Column("RequesterLoggedID")]
        [StringLength(1000)]
        public string RequesterLoggedId { get; set; }
        [Required]
        [Column("RequesterUserID")]
        [StringLength(1000)]
        public string RequesterUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LoggedTime { get; set; }
        public bool ApproverL1 { get; set; }
        public bool ApproverL2 { get; set; }
        public bool ApproverL3 { get; set; }
        [StringLength(100)]
        public string ApplicationCriticality { get; set; }
        [StringLength(100)]
        public string VmType { get; set; }
        [Column("SIEM")]
        [StringLength(100)]
        public string Siem { get; set; }
        [StringLength(1000)]
        public string GrowthFactor { get; set; }
        [StringLength(1000)]
        public string OtherCriteria { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsTicketClosed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TicketClosedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedOn { get; set; }
        [StringLength(100)]
        public string TapApprovalDoc { get; set; }
        [StringLength(100)]
        public string SolutionDesignDoc { get; set; }
        [StringLength(100)]
        public string SecurityApprovalDoc { get; set; }
        [StringLength(100)]
        public string BuildSheetDoc { get; set; }
        [Column("TapApprovalDocURL")]
        [StringLength(100)]
        public string TapApprovalDocUrl { get; set; }
        [Column("SolutionDesignDocURL")]
        [StringLength(100)]
        public string SolutionDesignDocUrl { get; set; }
        [Column("SecurityApprovalDocURL")]
        [StringLength(100)]
        public string SecurityApprovalDocUrl { get; set; }
        [Column("BuildSheetDocURL")]
        [StringLength(100)]
        public string BuildSheetDocUrl { get; set; }

        [InverseProperty("Request")]
        public virtual ICollection<TblVmapprovalRejection> TblVmapprovalRejection { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<TblVmdocument> TblVmdocument { get; set; }
    }
}
