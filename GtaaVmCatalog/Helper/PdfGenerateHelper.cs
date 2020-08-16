using GtaaVmCatalog.Controllers;
using GtaaVmCatalog.Models;
using GtaaVmCatalog.ViewModel;
using Newtonsoft.Json;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace GtaaVmCatalog.Helper
{
    public class PdfGenerateHelper
    {

        private AcquiredVmDetails GetVMDetails(int requestID)
        {
            VMDetailsController objVMDetailsController = new VMDetailsController();
            AcquiredVmDetails objAcquiredVmDetails = objVMDetailsController.Post(requestID);
            return objAcquiredVmDetails;
        }

        private string CreateHTMLString(AcquiredVmDetails objAcquiredVMDetailsViewModel, int requestID)
        {
            string str = string.Empty;
            str = $@"<html>
                    <head>
                    </head>
                    <body>
                       <h4>Request Numer: REQ {requestID}</h4>      
                    <div>       
                       <div>
                       <table border='1' width='500px'  cellpadding='0' cellspacing='0'>
                        <tr>
                            <td><b>Project Name</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.ProjectName}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td><b>Quote ID</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.QuoteIdnumber}</td>
                        </tr>
                        <tr>
                            <td><b>Project Number</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.ProjectNumber}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td><b>Change Order Number</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.ChangeRequestNumber}</td>
                         </tr>
                         <tr>
                            <td><b>Requester Name</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.RequesterUserId}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td><b>Agreement Number</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.AgreementNumber}</td>
                         </tr>
                          <tr>
                            <td><b>Architect Name</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.ArchitectName}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td><b>Release Number</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.ReleaseNumber}</td>
                          </tr>
                          <tr>
                            <td><b>PDM Name</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.Pdmname}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td><b>Change Request Number</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.ChangeRequestNumber}</td>
                          </tr>
                        </table>
                        <br />
                        <div>
                          <label for='briefDescription'><b>Description</b></label>
                          <span class='form-control description' id='briefDescription'>
                            {objAcquiredVMDetailsViewModel.tblVmproject.BriefDescription}
                          </span>
                        </div>
                        <table border='1' width='500px' cellpadding='0' cellspacing='0'>
                          <tr>
                            <td><b>VM Type</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.VmType}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td><b>Application Criticality</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.ApplicationCriticality}</td>
                          </tr>
                          <tr>
                            <td><b>SIEM Required</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.Siem}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td><b>Growth Factor</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.GrowthFactor}</td>
                          </tr>
                          <tr>
                            <td><b>Any other criteria?</b></td>
                            <td>{objAcquiredVMDetailsViewModel.tblVmproject.OtherCriteria}</td>
                            <td>&nbsp;&nbsp;</td>
                            <td>&nbsp;&nbsp;</td>
                            <td>&nbsp;&nbsp;</td>
                          </tr>
                        </table>
                    </div>";

            str += @"<div>
                <table border='1' width='500px' cellpadding='0' cellspacing='0'>
                <thead>
                 <tr>
                      <th>VM Environment</th>
                      <th>OS</th>
                      <th>CPU</th>
                      <th>RAM</th>
                      <th>Storage</th>
                      <th>Monitoring</th>
                     
                 </tr>
                </thead>
                <tbody>";

            foreach (AquiredVmSpecification data in objAcquiredVMDetailsViewModel.aquiredVmSpecification)
            {
                str += $@"<tr>
                        <td>{ data.VmEnvironment}</td>
   
                        <td>{ data.VmOs}</td>
        
                        <td>{ data.VmCpuType}</td>
             
                        <td>{ data.VmRamType}</td>
                  
                        <td>{ data.VmStorageType}</td>
                       
                        <td>{ data.VmMonitoringType}</td>
                      </tr>";
            }
            str += $@"</tbody>
        </table>
      </div>
      <br/>
      <div>
         <div>
           <b> Virtual Machine Cost</b>
           </br>
        </div>
      <br>
        <div>
          <span><b><u>CAPEX Cost</u></b></span>
          <br/>
          <div>
              {CapexCostGenerate(requestID)}
           </div>
        </div>
      <br/>
      <div>
          <span><b><u>OPEX Cost</u></b></span>
          <br/>
            <div>
                  {OpexCostGenerate(requestID)}
            </div>
        </div>
      </div>
    </div>
  </body>
</html>";

            return str;

        }

        public void GeneratePDF(int requestId)
        {
            try
            {
                AcquiredVmDetails objAcquiredVmDetails = GetVMDetails(requestId);
                if (null != objAcquiredVmDetails)
                {
                    string str = CreateHTMLString(objAcquiredVmDetails, requestId);
                    if (null != str && str.Length > 0)
                    {
                        PdfDocument objPDF = PdfGenerator.GeneratePdf(str, PdfSharp.PageSize.A4);
                        objPDF.Save(@"C:\Users\gtaadmin\Gtaa_VMCatalog\VMCatalog\GtaaVmCatalog\Pdf\abcd.pdf");
                    }
                }
            }
            catch
            { 
            
            
            }
        }

        public string OpexCostGenerate(int requestId)
        {
            string str = string.Empty;
            List<OpexCostYearMonth> lstCostBo = null;
            using (var objDbContext = new VMCatalogDBContext())
            {
                List<TblOpexCostDetail> objTblOpexCostDetailLst = objDbContext.TblOpexCostDetail.Where(objTblOpexCostDetail => objTblOpexCostDetail.RequestId == requestId).ToList();
                lstCostBo = (from objTblOpexCost in objTblOpexCostDetailLst
                                          group objTblOpexCost by new { objTblOpexCost.Year, objTblOpexCost.Months } into yearGroup
                                          orderby yearGroup.Key.Year
                                          select new OpexCostYearMonth { Year = yearGroup.Key.Year, Month = yearGroup.Key.Months, CostAmount = yearGroup.Sum(objOpexCost => objOpexCost.ActualCost) }
                                          ).ToList();

            }
            if (null != lstCostBo && lstCostBo.Count > 0)
            {
                int columns = lstCostBo.Count;
                str = "<table border = '1' width = '500px' cellpadding = '0' cellspacing = '0' >";
                str += "<thead>";
                str += "<tr>";
                str += "<th>&nbsp;</th>";
                foreach (OpexCostYearMonth objOpexCostYearMonth in lstCostBo)
                {
                    str += "<th>"+ objOpexCostYearMonth.Year + "</th>";


                }
                str += "</tr>";
                str += "</thead>";
                str += "<tbody>";
                str += "<tr>";
                str += "<td>#Months</td>";
                foreach (OpexCostYearMonth objOpexCostYearMonth in lstCostBo)
                {
                    str += "<td>" + objOpexCostYearMonth.Month + "</td>";

                }
                str += "</tr>";
                str += "<tr>";
                str += "<td>Cost Per Year</td>";
                foreach (OpexCostYearMonth objOpexCostYearMonth in lstCostBo)
                {
                    str += "<td>" + objOpexCostYearMonth.CostAmount + "</td>";

                }
                str += "</tr>";
                str += "<tr>";
                str += "<td>Total</td>";
                str +=$"<td colspan='{lstCostBo.Count}'>{lstCostBo.Sum(obj=> obj.CostAmount)}</td>";
                str += "</tr>";
                str += "</tbody>";
                str += "</table>";
            }

            return str; 
        
        
        }
        public string CapexCostGenerate(int requestId)
        {
            List<CapexViewModel> objCapexViewModelLst = null;
            string str = string.Empty;
            CapexController objCapexController = new CapexController();
            string strObj= objCapexController.Get(requestId);
            if (strObj != null)
            {
                 objCapexViewModelLst = JsonConvert.DeserializeObject<List<CapexViewModel>>(objCapexController.Get(requestId));
                if (null != objCapexViewModelLst && objCapexViewModelLst.Count > 0)
                {
                    str = "<table border = '1' width = '500px' cellpadding = '0' cellspacing = '0' >";
                    str += "<thead>";
                    str += "<tr>";
                    str += "<th>VM Type</th>";
                    str += "<th>Capex Cost</th>";
                    str += "</tr>";
                    str += "</thead>";
                    str += "<tbody>";
                    foreach (CapexViewModel objCapexViewModel in objCapexViewModelLst)
                    {
                        str += "<tr>";
                        str += $"<td>{objCapexViewModel.vmCategory}</td>";
                        str += $"<td>{objCapexViewModel.CapexList.Sum(objCapexEnvironment => objCapexEnvironment.CapexCost)}</td>";
                        str += "</tr>";
                    }
                    str += "<tr>";
                    str += $"<td>Total</td>";
                    str += $"<td>{objCapexViewModelLst.Sum(objCapexViewModel => objCapexViewModel.CapexList.Sum(objCapexEnvironment => objCapexEnvironment.CapexCost))}</td>";
                    str += "</tr>";
                    str += "</tbody>";
                    str += "</table>";
                }
            
            }

            return str;
        
        }
    }
}

 

              
      
                
