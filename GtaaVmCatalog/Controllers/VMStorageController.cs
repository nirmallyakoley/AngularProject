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
    public class VMStorageController : ControllerBase
    {
        // GET: api/VMStorage
        [HttpGet]
        public IEnumerable<TblVmStorageType> Get()
        {
            VMCatalogDBContext obj = new VMCatalogDBContext();
            return obj.TblVmStorageType.ToList<TblVmStorageType>();
        }
       
    }
}
