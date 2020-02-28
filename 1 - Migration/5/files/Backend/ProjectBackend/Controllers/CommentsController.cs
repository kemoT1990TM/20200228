using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectCloudyna.Services;
using System;

namespace ProjectCloudyna.Models
{
    [Route("api/[controller]")]
    [EnableCors("allowAll")]
    //TODO add error when not connected to db 
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public CommentsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        //// GET: api/Comments/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Comments
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // POST: api/Comments/5
        [HttpPost("{id}")]
        public void Post(string id, [FromBody] Comment comment)
        {
            Ticket ticket = _ticketService.Get(id);
            comment.DataTime = DateTime.UtcNow;

            ticket.Comments.Add(comment);

            _ticketService.Update(id, ticket);
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
