using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtaaVmCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OpexCostController : ControllerBase
    {
       

        // GET: api/OpexCost/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            OpexViewModel objOpexViewModel = null;
            try
            {
                using (var objDbContext = new VMCatalogDBContext())
                {
                    List<TblOpexCostDetail> objTblOpexCostDetailLst = objDbContext.TblOpexCostDetail.Where(objTblOpexCostDetail => objTblOpexCostDetail.RequestId == id).ToList();

                    int vmNumber = objTblOpexCostDetailLst.GroupBy(obgTblOpexCostDetail => obgTblOpexCostDetail.VmrequisitionId).Count();

                   List<int?> yearList= objTblOpexCostDetailLst.Select(obgTblOpexCostDetail => obgTblOpexCostDetail.Year).Distinct().ToList();

                    List<CostBO> lstCostBo = (from objTblOpexCost in objTblOpexCostDetailLst
                                         group objTblOpexCost by new { objTblOpexCost.Year, objTblOpexCost.OpexType } into yearGroup
                                         select new CostBO { Year = yearGroup.Key.Year, CostType = yearGroup.Key.OpexType, CostAmount = yearGroup.Sum(objOpexCost => objOpexCost.ActualCost) }).ToList();

                                         
                  
                    objOpexViewModel = new OpexViewModel()
                    {
                        VmNumber = vmNumber,
                        OpexCostCollection = lstCostBo,
                        YearList= yearList

                    };
                }
            }
            catch
            {
                objOpexViewModel = new OpexViewModel();
            }
            return JsonConvert.SerializeObject(objOpexViewModel);           
           
        }

      
    }
}
