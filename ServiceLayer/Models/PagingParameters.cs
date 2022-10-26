using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class PagingParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 100;
       
    }
}
