using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLayer.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageURL { get; set; }
        [ForeignKey("Category")]
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
