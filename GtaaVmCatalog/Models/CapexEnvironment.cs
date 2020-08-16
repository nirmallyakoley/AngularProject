using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtaaVmCatalog.Models
{
    public class CapexEnvironment
    {
        public int VmRequisitionId { get; set; }
        public string Environment { get; set; }
        public string CapexType { get; set; }
       
        public int? CapexUnit { get; set; }
      
        public decimal? CapexPerUnitCost { get; set; }
       
        public decimal? CapexCost { get; set; }
    }
}
