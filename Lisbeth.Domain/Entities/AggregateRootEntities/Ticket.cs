using System.Collections.Generic;
using Lisbeth.Domain.Entities.Base;
using Lisbeth.Domain.Entities.EnvironmentSpecificEntities;

namespace Lisbeth.Domain.Entities.AggregateRootEntities
{
    public class Ticket : RepositoryEntity, IAggregateRootEntity
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
