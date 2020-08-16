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
    public class VMOsController : ControllerBase
    {
        // GET: api/VMOs
        [HttpGet]
        public IEnumerable<TblVmOsType> Get()
        {
            VMCatalogDBContext objVMCatalogDBContext = new VMCatalogDBContext();
            return objVMCatalogDBContext.TblVmOsType.ToList<TblVmOsType>();
        }

      
    }
}
