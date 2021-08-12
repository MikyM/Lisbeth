﻿using Lisbeth.Domain.Entities.Base;
using System.Collections.Generic;

namespace Lisbeth.Domain.Entities
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public List<Attachment> Attachments { get; set; }
        public User CreatedBy { get; set; }
        public Ticket Ticket { get; set; }
        public Bug Bug { get; set; }
    }
}