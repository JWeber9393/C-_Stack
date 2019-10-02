using System.Collections.Generic;

namespace Products_and_Categories.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Category> CatsOfProd { get; set; }
        public Association association { get; set; }
        public List<Category> notMyCats { get; set; }
    }
}