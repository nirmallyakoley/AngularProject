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
    public class QuoteIdController : ControllerBase
    {
        // GET: api/QuoteId
        [HttpGet]
        public string Get()
        {
            TblVmproject[] tblVmproject = new TblVmproject[] { };
            string quoteIdNumber = string.Empty;
            int quoteId = 0;
            using (VMCatalogDBContext vMCatalogDBContext=new VMCatalogDBContext())
            {
                tblVmproject = vMCatalogDBContext.TblVmproject.OrderByDescending(obj => obj.RequestId).Take(1).ToArray();
            }
            if (tblVmproject.Length == 0)
            {
                quoteIdNumber = "GTAA-0001";
                return quoteIdNumber;
            }
            else
            {
                quoteId = Convert.ToInt32(tblVmproject[0].QuoteIdnumber.Substring(5));
                if (quoteId >= 1 && quoteId <= 8)
                    quoteIdNumber = "GTAA-000";
                else if (quoteId >= 9 && quoteId <= 98)
                    quoteIdNumber = "GTAA-00";
                else if (quoteId >= 99 && quoteId <= 998)
                    quoteIdNumber = "GTAA-0";
                else
                    quoteIdNumber = "GTAA-";
            }
            quoteId += 1;
            return  quoteIdNumber+ quoteId;
        }

    }
}
