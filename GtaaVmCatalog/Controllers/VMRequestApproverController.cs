using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using GtaaVmCatalog.Helper;
using GtaaVmCatalog.Models;
using GtaaVmCatalog.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VMRequestApproverController : ControllerBase
    {
        // GET: /VMRequestApprover

        [HttpPost("{approverLevel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public TblVmproject[] Post(string approverLevel)
        {
            TblVmproject[] arrTblVmproject = new TblVmproject[] { };

            using (VMCatalogDBContext objVMCatalogDBContext = new VMCatalogDBContext())
            {
                if (approverLevel == HelperConstant.PDM_APPROVER)
                {
                    arrTblVmproject = (from objTblPdmQueue in objVMCatalogDBContext.TblPdmQueue
                                       join objTblVmproject in objVMCatalogDBContext.TblVmproject
                                       on objTblPdmQueue.RequestId equals objTblVmproject.RequestId
                                       where (objTblVmproject.IsDeleted != true && objTblVmproject.IsTicketClosed != true)
                                       orderby objTblVmproject.RequestId
                                       select objTblVmproject).ToArray();

                    //arrTblVmproject = objVMCatalogDBContext.TblVmproject.Where(obj => ((obj.ApproverL1 == false) && (obj.IsDeleted != true))).OrderBy(objTblVmproject => objTblVmproject.RequestId).ToArray();
                }
                else if (approverLevel == HelperConstant.TAP_APPROVER)
                {
                    arrTblVmproject = (from objTblTapQueue in objVMCatalogDBContext.TblTapQueue
                                       join objTblVmproject in objVMCatalogDBContext.TblVmproject
                                       on objTblTapQueue.RequestId equals objTblVmproject.RequestId
                                       where (objTblVmproject.IsDeleted != true && objTblVmproject.IsTicketClosed != true)
                                       orderby objTblVmproject.RequestId
                                       select objTblVmproject).ToArray();
                    //arrTblVmproject = objVMCatalogDBContext.TblVmproject.Where(obj => ((obj.ApproverL1 == true) && (obj.ApproverL2 == false) && (obj.IsDeleted != true))).OrderBy(objTblVmproject => objTblVmproject.RequestId).ToArray();
                }
                else if(approverLevel == HelperConstant.DIRECTOR_APPROVER) 
                {
                    arrTblVmproject = (from objTblDirectorQueue in objVMCatalogDBContext.TblDirectorQueue
                                       join objTblVmproject in objVMCatalogDBContext.TblVmproject
                                       on objTblDirectorQueue.RequestId equals objTblVmproject.RequestId
                                       where (objTblVmproject.IsDeleted != true && objTblVmproject.IsTicketClosed != true)
                                       orderby objTblVmproject.RequestId
                                       select objTblVmproject).ToArray();
                    //arrTblVmproject = objVMCatalogDBContext.TblVmproject.Where(obj => ((obj.ApproverL1 == true) && (obj.ApproverL2 == true) && (obj.ApproverL3 == false) && (obj.IsDeleted != true))).OrderBy(objTblVmproject => objTblVmproject.RequestId).ToArray();
                }
            }
            return arrTblVmproject;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] VMApprovalViewModel objVMApprovalViewModel)
        {
            using (VMCatalogDBContext objVMCatalogDBContext = new VMCatalogDBContext())
            {            
                objVMCatalogDBContext.TblVmproject.Update(objVMApprovalViewModel.TblVmproject);
                TblVmapprovalRejection objTblVmapprovalRejection = new TblVmapprovalRejection() {RequestId= objVMApprovalViewModel.TblVmproject.RequestId, ApprovalLevel= objVMApprovalViewModel.TblVmapprovalRejection.ApprovalLevel, ApprovedOrRejectedBy= objVMApprovalViewModel.TblVmapprovalRejection.ApprovedOrRejectedBy,Status=objVMApprovalViewModel.TblVmapprovalRejection.Status};
                objVMCatalogDBContext.TblVmapprovalRejection.Add(objTblVmapprovalRejection);
                switch (objVMApprovalViewModel.TblVmapprovalRejection.ApprovalLevel)
                {
                    case HelperConstant.PDM_APPROVER:
                        objVMCatalogDBContext.TblPdmQueue.Remove(objVMCatalogDBContext.TblPdmQueue.Where(obj => obj.RequestId == objVMApprovalViewModel.TblVmproject.RequestId).SingleOrDefault());
                        if (objVMApprovalViewModel.TblVmapprovalRejection.Status == "Approved")
                        {                           
                            objVMCatalogDBContext.TblTapQueue.Add(new TblTapQueue { RequestId = objVMApprovalViewModel.TblVmproject.RequestId });
                        }
                        break;
                    case HelperConstant.TAP_APPROVER:
                        
                        objVMCatalogDBContext.TblTapQueue.Remove(objVMCatalogDBContext.TblTapQueue.Where(obj => obj.RequestId == objVMApprovalViewModel.TblVmproject.RequestId).SingleOrDefault());
                        
                        if (objVMApprovalViewModel.TblVmapprovalRejection.Status == "Approved")                        {
                           
                            objVMCatalogDBContext.TblDirectorQueue.Add(new TblDirectorQueue { RequestId = objVMApprovalViewModel.TblVmproject.RequestId });
                        }
                        else
                        {
                            objVMCatalogDBContext.TblPdmQueue.Add(new TblPdmQueue { RequestId = objVMApprovalViewModel.TblVmproject.RequestId });
                        }
                        break;

                    case HelperConstant.DIRECTOR_APPROVER:
                        objVMCatalogDBContext.TblDirectorQueue.Remove(objVMCatalogDBContext.TblDirectorQueue.Where(obj => obj.RequestId == objVMApprovalViewModel.TblVmproject.RequestId).SingleOrDefault());
                        if (objVMApprovalViewModel.TblVmapprovalRejection.Status != "Approved")
                        {
                            objVMCatalogDBContext.TblTapQueue.Add(new TblTapQueue { RequestId = objVMApprovalViewModel.TblVmproject.RequestId });

                        }
                        else//if approved//
                        {
                            PdfGenerateHelper objPdfGenerateHelper = new PdfGenerateHelper();
                            objPdfGenerateHelper.GeneratePDF(objVMApprovalViewModel.TblVmproject.RequestId);
                        }


                        break;


                }
                
                
                objVMCatalogDBContext.SaveChanges();
                return Ok(new { message = "success", status = "201" });
            }
            
        }

     
    }
}
