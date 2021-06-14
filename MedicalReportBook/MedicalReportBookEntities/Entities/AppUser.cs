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
        public AppUser()
        {
            ConsultancyReports = new HashSet<ConsultancyReport>();
        }
        [Key]
        public int UserId { get; set; }
        [Required,MaxLength(30),MinLength(3)]
        public string FirstName { get; set; }
        [MinLength(3),MaxLength(30)]
        public string MiddleName { get; set; }
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        
        public long PhoneNumber { get; set; }        
        public string Address { get; set; }
        [EmailAddress]
        [Required]        
        public string EmailId { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        [StringLength(30,MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Required]
        [StringLength(30, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }


        public virtual ICollection<ConsultancyReport> ConsultancyReports { get; set; }

       
    }
}
