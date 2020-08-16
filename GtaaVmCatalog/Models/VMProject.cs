using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtaaVmCatalog.Model
{
    public class VMProject
    {
        public string RequestID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string RequesterName { get; set; }
        public string ArchitectName { get; set; }
        public string PDMName { get; set; }
        public string QuoteIDNumber { get; set; }
        public string ChangeOrderNumber { get; set; }
        public string AgreementNumber { get; set; }
        public string ReleaseNumber { get; set; }
        public string ChangeRequestNumber { get; set; }
        public string BriefDescription { get; set; }
        public string RequesterLoggedID { get; set; }
    }
}
