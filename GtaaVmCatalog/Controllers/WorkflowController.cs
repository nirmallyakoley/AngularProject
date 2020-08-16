using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtaaVmCatalog.Helper;
using GtaaVmCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        // GET: api/Workflow
        [HttpPost]
        public string Post([FromBody] int vmRequestId)
        {
            List<TblVmapprovalRejection> tblVmapprovalRejections = new List<TblVmapprovalRejection>();
            using (VMCatalogDBContext vMCatalogDBContext = new VMCatalogDBContext())
            {
                List<TblVmapprovalRejection> tblVmapprovalRejectionsList = vMCatalogDBContext.TblVmapprovalRejection.Where(obj => obj.RequestId == vmRequestId).OrderBy(obj => obj.ApprovalRejectionId).ToList();
                if (null != tblVmapprovalRejectionsList)
                {
                    if (tblVmapprovalRejectionsList.Count > 0)
                    {
                        tblVmapprovalRejections.AddRange(tblVmapprovalRejectionsList);                            
                    }
                }
                //checking approval pending  label//
                TblVmproject objTblVmproject = vMCatalogDBContext.TblVmproject.Where(objTblVmproject => objTblVmproject.RequestId == vmRequestId).SingleOrDefault();
                if (null != objTblVmproject)
                {
                    if (!objTblVmproject.ApproverL1)
                    {
                        tblVmapprovalRejections.Add(new TblVmapprovalRejection {RequestId=vmRequestId,ApprovalLevel= HelperConstant.PDM_APPROVER,Status="Pending",ApprovedOrRejectedBy="PDM Level"});
                    }
                    if (!objTblVmproject.ApproverL2)
                    {
                        tblVmapprovalRejections.Add(new TblVmapprovalRejection { RequestId = vmRequestId, ApprovalLevel = HelperConstant.TAP_APPROVER, Status = "Pending", ApprovedOrRejectedBy = "TAP Level" });
                    }
                    if (!objTblVmproject.ApproverL3)
                    {
                        tblVmapprovalRejections.Add(new TblVmapprovalRejection { RequestId = vmRequestId, ApprovalLevel = HelperConstant.DIRECTOR_APPROVER, Status = "Pending", ApprovedOrRejectedBy = "DIRECTOR Level" });
                    }
                }


            }
            return JsonConvert.SerializeObject(tblVmapprovalRejections);
        }
    }
}
