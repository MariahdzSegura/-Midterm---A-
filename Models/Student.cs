using System.ComponentModel.DataAnnotations;

namespace Myexam200.Models 
{
    public class Student
    {
        public int StudentId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; } 

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string? LastName { get; set; }  

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? EmailAddress { get; set; } 
    }
}