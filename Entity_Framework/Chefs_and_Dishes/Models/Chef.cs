using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs_and_Dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required(ErrorMessage = "Please enter first name!")]
        public string _fname { get; set; }
        
        [Required(ErrorMessage = "Please enter last name!")]
        public string _lname { get; set; }
        
        [Required(ErrorMessage = "Please enter DOB!")]
        [Display(Name = "Date of Birth:")]
        public DateTime _birthday { get; set; }

        [Required]
        public int _age {get; set;}

        public List<Dish> CreatedDishes{ get; set; }
        

        // We can provide some hardcoded default values like so:
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}