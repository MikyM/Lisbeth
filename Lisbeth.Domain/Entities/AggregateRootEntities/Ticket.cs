using System.Collections.Generic;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities.AggregateRootEntities
{
    public class Ticket : AggregateRootEntity
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }
        public long TrackerId { get; set; }
        public Tracker Tracker { get; set; }
        public List<TicketHistoryLog> History { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Comment> Comments { get; set; }
        public User FixedBy { get; set; }
        public User CreatedBy { get; set; }
        public long QueueId { get; set; }
        public Queue Queue { get; set; }
    }
}
