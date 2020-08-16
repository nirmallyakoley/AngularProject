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
    public class CapexController : ControllerBase
    {
       
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<CapexViewModel> objCapexViewModelLst = null;
            try
            {
                using (var objDbContext = new VMCatalogDBContext())
                {
                    List<TblCapexCostDetail> lstTblCapexCostDetail = objDbContext.TblCapexCostDetail.Where(objTblCapexCostDetail => objTblCapexCostDetail.RequestId == id).ToList();
                    if (lstTblCapexCostDetail != null && lstTblCapexCostDetail.Count > 0)
                    {
                        List<CapexEnvironment> capexDataSet = (from objTblCapexCostDetail in lstTblCapexCostDetail
                                            join objEnvironment in objDbContext.TblVmEnvironmentType on objTblCapexCostDetail.VmenvironmentTypeId equals objEnvironment.VmenvironmentTypeId
                                            orderby objTblCapexCostDetail.CreatedOn
                                            select new CapexEnvironment{
                                                VmRequisitionId= objTblCapexCostDetail.VmrequisitionId,
                                                Environment =objEnvironment.Vmenvironment,
                                                CapexType=objTblCapexCostDetail.CapexType,
                                                CapexUnit=objTblCapexCostDetail.CapexUnit,
                                                CapexPerUnitCost=objTblCapexCostDetail.CapexPerUnitCost,
                                                CapexCost=objTblCapexCostDetail.CapexCost
                                            }).ToList();

                        var groupByEnvCapex = from objCapexEnvironment in capexDataSet
                                              group objCapexEnvironment by objCapexEnvironment.VmRequisitionId into newGroup
                                              select newGroup;
                        objCapexViewModelLst = new List<CapexViewModel>();
                        foreach (var environmentCapexGrp in groupByEnvCapex)
                        {
                            CapexViewModel objCapexViewModel = new CapexViewModel();
                            if (environmentCapexGrp != null && environmentCapexGrp.Count() > 0)
                            {
                                objCapexViewModel.vmCategory = $"{((CapexEnvironment)(environmentCapexGrp.ToList())[0]).Environment} - VM -";
                            }
                           
                            objCapexViewModel.CapexList = new List<CapexEnvironment>();
                            foreach (CapexEnvironment objCapexEnvironment in environmentCapexGrp)
                            {
                                objCapexViewModel.CapexList.Add(objCapexEnvironment);
                                objCapexViewModel.vmCategory += $"| {objCapexEnvironment.CapexType} - {objCapexEnvironment.CapexUnit}";
                            }

                            objCapexViewModelLst.Add(objCapexViewModel);
                        }

                    }
                }
                   
            }
            catch
            {
                objCapexViewModelLst = new List<CapexViewModel>() ;
            }
            return JsonConvert.SerializeObject(objCapexViewModelLst);

        }

    }
}