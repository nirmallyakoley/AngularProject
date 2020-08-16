using GtaaVmCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtaaVmCatalog.ViewModel
{
    public class AcquiredVmDetails
    {
        public TblVmproject tblVmproject { get; set; }
        public AquiredVmSpecification[] aquiredVmSpecification { get; set; }
    }
}
