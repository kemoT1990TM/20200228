using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectCloudyna.Models;
using ProjectCloudyna.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<Ticket>> Get()
        {
            return await _ticketService.Get();
        }

        // GET api/<controller>/UID
        [HttpGet("{id}")]
        public async Task<Ticket> Get(string id)
        {
            return await _ticketService.Get(id);
        }

        // GET api/<controller>/UID
        [HttpPost("{id}/close")]
        public async Task<Ticket> Close(string id)
        {
            var ticket = await _ticketService.Get(id);
            ticket.TicketStatus = TicketStatus.Closed;
            await _ticketService.Update(id, ticket);
            return await _ticketService.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<Ticket> Post([FromBody] Ticket ticket)
        {
            return await _ticketService.Create(ticket);

        }

    }
}