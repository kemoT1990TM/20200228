using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCloudyna.Models;
using ProjectCloudyna.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Extensions;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCloudyna.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("allowAll")]
    public class UploadController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly TicketService _ticketService;

        private readonly string _bucketName = "my-test-bucket-przemek";

        public UploadController(IHostingEnvironment hostingEnvironment, TicketService ticketService)
        {
            this._hostingEnvironment = hostingEnvironment;
            _ticketService = ticketService;

        }

        // POST api/<controller>/{Id}
        [HttpPost("{id}")]
        public async Task<IActionResult> OnPostUploadAsync(string id, /*[FromBody]*/IFormFile formFile)
        {
            var uniqueFileName = GetUniqueFileName(formFile.FileName);

            await UploadFileToS3(formFile, uniqueFileName);
            var fileEntity = new UploadedFile();
            fileEntity.CreationTime = DateTime.UtcNow;
            fileEntity.FileName = formFile.FileName;
            fileEntity.WebLocation =  "https://" + _bucketName + ".s3-eu-west-1.amazonaws.com/" + uniqueFileName;

            var ticket = await _ticketService.Get(id);
            ticket.Files.Add(fileEntity);
            await _ticketService.Update(id, ticket);

            return Ok(fileEntity);
        }

        private async Task UploadFileToS3(IFormFile file, string fileName)
        {
            using (var client = new AmazonS3Client())
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = fileName,
                        BucketName = _bucketName,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    var fileTransferUtility = new TransferUtility(client);
                    await  fileTransferUtility.UploadAsync(uploadRequest);
                   
                    
                }
            }
        }
        
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

    }
}
