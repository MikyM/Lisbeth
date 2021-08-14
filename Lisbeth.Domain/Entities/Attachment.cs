using System;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using MikyM.Common.Domain.Entities;

namespace Lisbeth.API.Domain.Entities
{
    public class Attachment : Entity
    {
        public Uri Uri { get; set; }
        public long? CommentId { get; set; }
        public Comment Comment { get; set; }
        public long? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public long? BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
