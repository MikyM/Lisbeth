using System.Collections.Generic;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities
{
    public class Bug : Entity
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public Tracker Tracker { get; set; }
        public Status Status { get; set; }
        public List<TicketHistoryLog> History { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Comment> Comments { get; set; }
        public User AssignedTo { get; set; }
        public User CreatedBy { get; set; }
        public Project Project { get; set; }
    }
}
