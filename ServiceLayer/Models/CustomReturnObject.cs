using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class CustomReturnObject 
    {
        public bool Success { set; get; }
        public object Results { set; get; }
        public string Message { set; get; }
    }
}
