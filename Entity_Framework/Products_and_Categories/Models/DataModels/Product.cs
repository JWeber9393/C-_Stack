using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products_and_Categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public decimal price { get; set; }

        public List<Association> catAssociation {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    
}