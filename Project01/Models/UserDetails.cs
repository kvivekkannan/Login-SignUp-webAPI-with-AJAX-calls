using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project01.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Enter your Email Address")]
        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Enter a valid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Enter the Username")]
        [Display(Name ="Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter the Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm the password")]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="Password & Confirm Password must match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Enter your Contact number")]
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }
    }
}