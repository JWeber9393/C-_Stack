using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Login_and_Registration.Models
{
    public class LogUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string log_email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string log_password { get; set; }
    }
}