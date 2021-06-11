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
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        
        public string UserType { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
       
    }
}
