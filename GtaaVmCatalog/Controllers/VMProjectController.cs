using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GtaaVmCatalog.Models;
using GtaaVmCatalog.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VMProjectController : ControllerBase
    {
        // POST: api/VMProject
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]VMRequetViewModel objVMRequetViewModel)
        {

            VMCatalogDBContext objDataContext = new VMCatalogDBContext();
            objDataContext.TblVmproject.Add(objVMRequetViewModel.TblVmproject);
            objDataContext.SaveChanges();

            TblVmproject objTblVmproject = objDataContext.TblVmproject.OrderByDescending(objTblVmproject => objTblVmproject.RequestId).FirstOrDefault<TblVmproject>();
            if (objTblVmproject != null)
            {
                int requestID = objTblVmproject.RequestId;
                objVMRequetViewModel.TblVmRequisitionDetailsList.ForEach(objTblVmRequisitionDetails => objTblVmRequisitionDetails.RequestId = requestID);
                objDataContext.TblVmRequisitionDetails.AddRange(objVMRequetViewModel.TblVmRequisitionDetailsList);
                //pushing to PDM Queue----------------------------//
                objDataContext.TblPdmQueue.Add(new TblPdmQueue {RequestId= requestID });
                //---PDM Queue added-----------------------------//
                objDataContext.SaveChanges();
                using (var cmd = objDataContext.Database.GetDbConnection().CreateCommand())
                {
                    //Execute SP 1
                    cmd.CommandText = "usp_InsertCapexData";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RequestID", SqlDbType.TinyInt) { Value = requestID });
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();
                    cmd.ExecuteReader();
                    cmd.Connection.Close();
                }
                using (var OpexCmd = objDataContext.Database.GetDbConnection().CreateCommand())
                {
                    //Execute SP2
                    OpexCmd.CommandText = "usp_InsertOpexVmCost";
                    OpexCmd.CommandType = CommandType.StoredProcedure;
                    OpexCmd.Parameters.Add(new SqlParameter("@RequestID", SqlDbType.TinyInt) { Value = requestID });
                    if (OpexCmd.Connection.State != ConnectionState.Open)
                        OpexCmd.Connection.Open();
                    OpexCmd.ExecuteReader();
                    OpexCmd.Connection.Close();
                }
            }
            return Ok(new { message = "success", status = "201" });
        }

        //Fetch VM Request List//
        [HttpGet("{userID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public TblVmproject[] Get(string userID)
        {
            VMCatalogDBContext obj = new VMCatalogDBContext();
            TblVmproject[] objList = obj.TblVmproject.Where(objVM => !objVM.IsTicketClosed && !objVM.IsDeleted && objVM.RequesterUserId == userID).OrderByDescending(VmProjectOb => VmProjectOb.LoggedTime).ToArray();
            return objList;
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put([FromBody]TblVmproject objTblVmproject)
        {
            using (VMCatalogDBContext objDataContext = new VMCatalogDBContext())
            {
                objTblVmproject.IsDeleted = true;
                objTblVmproject.DeletedOn = DateTime.Now;
                objDataContext.TblVmproject.Update(objTblVmproject);
                objDataContext.SaveChanges();
                return Ok(new { message = "success", status = "201" });
            }
            
        }





    }
}
