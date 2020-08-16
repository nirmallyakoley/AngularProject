using GtaaVmCatalog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtaaVmCatalog.ViewModel
{
    public class VMRequetViewModel
    {
        
        public TblVmproject TblVmproject { get; set; }


        
        public List<TblVmRequisitionDetails> TblVmRequisitionDetailsList { get; set; }

    }
}
