using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtaaVmCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VmMonitoringController : ControllerBase
    {
        [HttpGet]
        public TblVmMonitoringType[] Get()
        {
            TblVmMonitoringType[] objTblVmMonitoringType = new TblVmMonitoringType[] { };
            using (VMCatalogDBContext objVMCatalogDBContext=new VMCatalogDBContext())
            {
                objTblVmMonitoringType=objVMCatalogDBContext.TblVmMonitoringType.ToArray();
            }
            return objTblVmMonitoringType;
        }
    }
}
