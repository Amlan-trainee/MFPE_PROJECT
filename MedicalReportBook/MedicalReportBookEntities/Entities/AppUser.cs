using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookEntities.Entities
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        [Required,MaxLength(30),MinLength(3)]
        public string FirstName { get; set; }
        [MinLength(3),MaxLength(30)]
        public string MiddleName { get; set; }
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Pleasse enter your gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Pleasse enter the phone number")]
        [RegularExpression("^[\\d]{10}",ErrorMessage ="Please put a valid phone number")]
        public long PhoneNumber { get; set; }
        
        public string Address { get; set; }
        [EmailAddress]
        public string EmailId { get; set; }
        
        public string UserType { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Range(8,30,ErrorMessage ="Password should be minimum 8 characters and maximum 30 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Required(ErrorMessage = "Confirm Password is required")]
        [Range(8, 30)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="This must match the Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
       
    }
}
