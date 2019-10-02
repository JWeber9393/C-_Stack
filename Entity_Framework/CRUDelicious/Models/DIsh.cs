using System.ComponentModel.DataAnnotations;
using System;
namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [MaxLength(45)]
        [Display(Name = "Dish Name:")]
        public string Name { get; set; }
        [MaxLength(45)]
        [Display(Name = "Dish Chef:")]
        public string Chef { get; set; }
        [Display(Name = "Tastiness:")]
        public int Tastiness { get; set; }
        [Display(Name = "Calories:")]
        public int Calories { get; set; }
        [Display(Name = "Description:")]
        public string Description { get; set; }

        // We can provide some hardcoded default values like so:
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // New User objects will these values assigned
        // However, when we query existing data, CreatedAt/UpdatedAt will refer to 
        // values that are stored in the DB
    }
}
