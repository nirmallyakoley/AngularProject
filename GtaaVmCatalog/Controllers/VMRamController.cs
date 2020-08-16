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
    public class VMRamController : ControllerBase
    {
        // GET: api/VMRam
        [HttpGet]
        public IEnumerable<TblVmRamType> Get()
        {
            VMCatalogDBContext objVMCatalogDBContext = new VMCatalogDBContext();
            return objVMCatalogDBContext.TblVmRamType.ToList<TblVmRamType>();
        }        
    }
}
