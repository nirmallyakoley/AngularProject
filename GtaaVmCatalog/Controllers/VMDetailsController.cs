using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtaaVmCatalog.Models;
using GtaaVmCatalog.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VMDetailsController : ControllerBase
    {
        // GET: api/VMDetails
        [HttpPost]
        public AcquiredVmDetails Post([FromBody] int requestId)
        {
            AcquiredVmDetails acquiredVmDetails = new AcquiredVmDetails();
            using (VMCatalogDBContext vMCatalogDBContext=new VMCatalogDBContext())
            {
                acquiredVmDetails.tblVmproject = vMCatalogDBContext.TblVmproject.Find(requestId);
                acquiredVmDetails.aquiredVmSpecification = (from rt in vMCatalogDBContext.TblVmRequisitionDetails
                                                           join et in vMCatalogDBContext.TblVmEnvironmentType on rt.VmenvironmentTypeId equals et.VmenvironmentTypeId
                                                           join ot in vMCatalogDBContext.TblVmOsType on rt.VmostypeId equals ot.VmostypeId
                                                           join ct in vMCatalogDBContext.TblVmCpuType on rt.Vmcpuid equals ct.Vmcpuid
                                                           join ramt in vMCatalogDBContext.TblVmRamType on rt.Vmramid equals ramt.Vmramid
                                                           join st in vMCatalogDBContext.TblVmStorageType on rt.Vmstorid equals st.Vmstorid
                                                           join mt in vMCatalogDBContext.TblVmMonitoringType on rt.VmmonitoringId equals mt.VmmonitoringId
                                                            where rt.RequestId== requestId
                                                            select  new AquiredVmSpecification
                                                           {
                                                               VmEnvironment=et.Vmenvironment,
                                                               VmOs=ot.Vmos,
                                                               VmCpuType=ct.Vmcputype,
                                                               VmRamType=ramt.Vmramtype,
                                                               VmStorageType=st.VmstorageType,
                                                               VmMonitoringType=mt.VmmonitoringType
                                                           }).ToArray();
                                                         
            }
            return acquiredVmDetails;

        }
    }
}
