using Lisbeth.Domain.Entities.Base;
using System.Collections.Generic;

namespace Lisbeth.Domain.Entities
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Bug> Bugs { get; set; }
        public Environment Environment { get; set; }
    }
}
