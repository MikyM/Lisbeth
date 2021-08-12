﻿using System.Collections.Generic;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Domain.Entities
{
    public class Queue : Entity
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
        public long EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
