using System.ComponentModel.DataAnnotations;

namespace Products_and_Categories.Models
{
    public class Association
    {
        [Key]
        public int Products_CategoriesID {get; set;}

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}