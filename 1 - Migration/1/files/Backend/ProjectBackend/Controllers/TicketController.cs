using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectCloudyna.Models;
using ProjectCloudyna.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCloudyna.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("allowAll")]
    //TODO add error when not connected to db 
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/<controller>
        [HttpGet]
        public List<Ticket> Get()
        {
            return _ticketService.Get();
        }

        // GET api/<controller>/UID
        [HttpGet("{id}")]
        public Ticket Get(string id)
        {
            return _ticketService.Get(id);
        }

        // GET api/<controller>/UID
        [HttpPost("{id}/close")]
        public Ticket Close(string id)
        {
            var ticket = _ticketService.Get(id);
            ticket.TicketStatus = TicketStatus.Closed;
            _ticketService.Update(id, ticket);
            return _ticketService.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public Ticket Post([FromBody] Ticket ticket)
        {
            return _ticketService.Create(ticket);

        }

    }
}