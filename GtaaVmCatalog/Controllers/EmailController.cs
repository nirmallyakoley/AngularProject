using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GtaaVmCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<CustomResponse> Post([FromBody] Email email)
        {
            HttpResponseMessage response = null;
            using (var client=new HttpClient())
            {
                string postBody = JsonConvert.SerializeObject(email);
                string url= "https://prod-20.canadacentral.logic.azure.com:443/workflows/cdfa3c6bf0634091b682a0c59a1e50de/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=HWI4x--WZDOHCukxSqRpRUhfQK_05GZ2FjAIuOlxUwY";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.PostAsync(url, new StringContent(postBody, System.Text.Encoding.UTF8, "application/json"));
                
            }
            if (response.IsSuccessStatusCode)
                return new CustomResponse() { message = "success", status = "201" };
            else
                return new CustomResponse() { message = "Bad request", status = "400" };
        }

    }
}
