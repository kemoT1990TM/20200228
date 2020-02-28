using MongoDB.Driver;
using ProjectCloudyna.Models;
using System;
using System.Collections.Generic;

namespace ProjectCloudyna.Services
{
    public class TicketService
    {
        private readonly IMongoCollection<Ticket> _tickets;

        public TicketService(ITicketsDatabaseSettings settings)
        {
            
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _tickets = database.GetCollection<Ticket>(settings.TicketsCollectionName);
            
        }

        public List<Ticket> Get()
        {
            return _tickets.Find(ticket => true).ToList();
        }

        public Ticket Get(string id)
        {
            return _tickets.Find(ticket => ticket.Id == id).FirstOrDefault();
        }

        public Ticket Create(Ticket ticket)
        {
            ticket.Id = string.Empty;
            ticket.DateTime = DateTime.UtcNow;
            ticket.TicketStatus = TicketStatus.Open;
            ticket.Comments = new List<Comment>();
            ticket.Files = new List<UploadedFile>();
            _tickets.InsertOne(ticket);
            return ticket;
        }

        public void Update(string id, Ticket ticketIn)
        {
            _tickets.ReplaceOne(ticket => ticket.Id == id, ticketIn);
        }

        public void Remove(Ticket ticketIn)
        {
            _tickets.DeleteOne(ticket => ticket.Id == ticketIn.Id);
        }

        public void Remove(string id)
        {
            _tickets.DeleteOne(ticket => ticket.Id == id);
        }
    }
}