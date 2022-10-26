using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class ProductBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }

    }
}
