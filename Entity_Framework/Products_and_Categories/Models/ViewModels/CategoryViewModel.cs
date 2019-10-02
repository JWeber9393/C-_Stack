using System.Collections.Generic;

namespace Products_and_Categories.Models
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public List<Product> ProdsOfCat { get; set; }
        public Association association { get; set; }
        public List<Product> notMyProds { get; set; }
    }
}