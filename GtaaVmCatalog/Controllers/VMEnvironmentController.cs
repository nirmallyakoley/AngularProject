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
    public class VMEnvironmentController : ControllerBase
    {
        // GET: api/VMEnvironment
        [HttpGet]
        public IEnumerable<TblVmEnvironmentType> Get()
        {
            VMCatalogDBContext obj = new VMCatalogDBContext();
            return obj.TblVmEnvironmentType.ToList<TblVmEnvironmentType>();
        }
        [HttpPost]
        public void  Post()
        {
            
        }


    }
}
