using System.Collections.Generic;

namespace Products_and_Categories.Models
{
    public class NewCategoryModel
    {
        public Category newCat { get; set; }
        public List<Category> allCategories { get; set; }
    }
}