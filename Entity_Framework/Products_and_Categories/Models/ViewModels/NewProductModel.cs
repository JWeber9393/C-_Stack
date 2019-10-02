using System.Collections.Generic;

namespace Products_and_Categories.Models
{
    public class NewProductModel
    {
        public Product newProd { get; set; }
        public List<Product> allProducts{ get; set; }
    }
}