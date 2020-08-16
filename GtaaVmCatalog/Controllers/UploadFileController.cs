using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtaaVmCatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GtaaVmCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IOptions<MyConfig> config;
        public UploadFileController(IOptions<MyConfig> config)
        {
            this.config = config;
        }

        // POST: api/UploadFile
        [HttpPost]
        public async Task<bool> Post(IFormFile myfile)
        {
            try
            {
                if (CloudStorageAccount.TryParse(config.Value.StorageConnection, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(config.Value.Container);
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(myfile.FileName);
                    await blockBlob.UploadFromStreamAsync(myfile.OpenReadStream());
                        return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
