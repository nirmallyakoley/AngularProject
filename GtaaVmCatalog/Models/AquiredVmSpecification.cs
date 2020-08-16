using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtaaVmCatalog.Models
{
    public class AquiredVmSpecification
    {
        public string VmEnvironment { get; set; }
        public string VmOs { get; set; }
        public string VmCpuType { get; set; }
        public string VmRamType { get; set; }
        public string VmStorageType { get; set; }
        public string VmMonitoringType { get; set; }
    }
}
