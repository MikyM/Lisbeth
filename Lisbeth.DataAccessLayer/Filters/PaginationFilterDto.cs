﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisbeth.DataAccessLayer.Filters
{
    public class PaginationFilterDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
