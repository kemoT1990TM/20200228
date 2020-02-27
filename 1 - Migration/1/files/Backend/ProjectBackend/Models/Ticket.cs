using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ProjectCloudyna.Models
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")] public string Email { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TicketStatus TicketStatus { get; set; }

        public List<Comment> Comments { get; set; }

        public List<UploadedFile> Files { get; set; }

    }

    public enum TicketStatus
    {
        Open,
        Closed
    }
}