using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ProjectCloudyna.Models
{
    [DynamoDBTable("YOUR-TABLE-NAME")]
    public class Ticket
    {
        [DynamoDBHashKey]
        public string Id  { get; set; }

        public string Email { get; set; }

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