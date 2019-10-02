using System;
using System.ComponentModel.DataAnnotations;
namespace Chefs_and_Dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Please enter dish name!")]
        [MaxLength(45)]
        [Display(Name = "Dish Name:")]
        public string _name { get; set; }


        [Required(ErrorMessage = "How tasty is this dish?")]
        [Range(1, 5)]
        [Display(Name = "Tastiness:")]
        public int _tastiness { get; set; }

        [Required(ErrorMessage = "How many calories in this dish?")]
        [Range(1, Int32.MaxValue)]
        [Display(Name = "Calories:")]
        public int _calories { get; set; }

        [Required(ErrorMessage = "Description required!")]
        [Display(Name = "Description:")]
        public string _description { get; set; }

        // We can provide some hardcoded default values like so:
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int ChefId {get; set;}

        public Chef Creator { get; set; }

        // New User objects will these values assigned
        // However, when we query existing data, CreatedAt/UpdatedAt will refer to 
        // values that are stored in the DB
    }
}