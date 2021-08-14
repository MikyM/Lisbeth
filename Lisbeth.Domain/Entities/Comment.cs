using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using MikyM.Common.Domain.Entities;
using System.Collections.Generic;

namespace Lisbeth.API.Domain.Entities
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public List<Attachment> Attachments { get; set; }
        public User CreatedBy { get; set; }
        public long? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public long? BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
