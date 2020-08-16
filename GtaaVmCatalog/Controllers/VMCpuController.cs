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
    public class VMCpuController : ControllerBase
    {
        // GET: api/VMCpu
        [HttpGet]
        public IEnumerable<TblVmCpuType> Get()
        {
            VMCatalogDBContext objVMCatalogDBContext = new VMCatalogDBContext();
            return objVMCatalogDBContext.TblVmCpuType.ToList<TblVmCpuType>();
        }       
    }
}
