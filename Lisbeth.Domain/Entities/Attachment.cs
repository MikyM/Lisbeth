using Lisbeth.Domain.Entities.Base;
using System;

namespace Lisbeth.Domain.Entities
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
