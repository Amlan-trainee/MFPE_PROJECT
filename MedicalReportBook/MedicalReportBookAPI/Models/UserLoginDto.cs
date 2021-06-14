using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;

namespace MedicalReportBookAPI.Models
{
    public class UserLoginDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "EmaiId feild is mandatory")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "Min Length should be 8 and Maximum should be 30", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}