using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using ProjectCloudyna.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCloudyna.Services
{
    public class TicketService
    {
        AmazonDynamoDBClient _client;
        Amazon.DynamoDBv2.DataModel.DynamoDBContext _context;
        public TicketService(ITicketsDatabaseSettings settings)
        {
            
            _client = new AmazonDynamoDBClient();
            _context = new Amazon.DynamoDBv2.DataModel.DynamoDBContext(_client);
        }

        public async Task<List<Ticket>> Get()
        {
            var conditions = new List<Amazon.DynamoDBv2.DataModel.ScanCondition>();
            var allTickets = await _context.ScanAsync<Ticket>(conditions).GetRemainingAsync();
            return allTickets;
        }

        public async Task<Ticket> Get(string id)
        {
            //return _tickets.Find(ticket => ticket.Id == id).FirstOrDefault();
            var item = await _context.LoadAsync<Ticket>(id);
            return item;
        }

        public async Task<Ticket> Create(Ticket ticket)
        {
            ticket.Id  = Guid.NewGuid().ToString().Replace("-", "");
            ticket.DateTime = DateTime.UtcNow;
            ticket.TicketStatus = TicketStatus.Open;
            ticket.Comments = new List<Comment>();
            ticket.Files = new List<UploadedFile>();
            //_tickets.InsertOne(ticket);
            await _context.SaveAsync(ticket);
            return ticket;
            
        }

        public async Task<Ticket> Update(string id, Ticket ticketIn)
        {
            //_tickets.ReplaceOne(ticket => ticket.Id == id, ticketIn);
            var ticket = await Get(id);
            ticket.Email = ticketIn.Email;
            ticket.Description = ticketIn.Description;
            ticket.DateTime = ticketIn.DateTime;
            ticket.TicketStatus = ticketIn.TicketStatus;
            ticket.Comments = ticketIn.Comments;
            ticket.Files = ticketIn.Files;
            await _context.SaveAsync(ticket);
            return ticket;
        }

        public async Task Remove(Ticket ticketIn)
        {
            await _context.DeleteAsync(ticketIn.Id);
        }

        public async Task Remove(string id)
        {
            await _context.DeleteAsync(id);
        }
    }
}