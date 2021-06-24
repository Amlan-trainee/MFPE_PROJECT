using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalReportBookAPI.Models
{
    /// <summary>
    /// Dto class for changing password .
    /// </summary>
    public class ChangePassowrdDto
    {
        public int User_Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}