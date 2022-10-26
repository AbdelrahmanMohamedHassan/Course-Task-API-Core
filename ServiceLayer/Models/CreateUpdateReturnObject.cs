using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class CreateUpdateReturnObject
    {
        public int ProductId { set; get; }
        public CustomReturnObject customReturn { set; get; }
    }
}
