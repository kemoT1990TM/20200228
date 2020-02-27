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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCloudyna.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("allowAll")]
    public class UploadController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly TicketService _ticketService;

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
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, uniqueFileName);
            Directory.CreateDirectory(uploads);

            if (formFile.Length > 0)
            {


                using (var stream = System.IO.File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" ;

            var fileEntity = new UploadedFile();
            fileEntity.CreationTime = DateTime.UtcNow;
            fileEntity.FileName = formFile.FileName;
            fileEntity.WebLocation = url +  "uploads/" + uniqueFileName;

            var ticket = _ticketService.Get(id);
            ticket.Files.Add(fileEntity);
            _ticketService.Update(id, ticket);

            return Ok(fileEntity);
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
