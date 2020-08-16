using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtaaVmCatalog.Models
{
    public class Email
    {
        public int requestId { get; set; }
        public string requestStatus { get; set; }
        public string email { get; set; }
        public string approverLevel { get; set; }
    }
}
