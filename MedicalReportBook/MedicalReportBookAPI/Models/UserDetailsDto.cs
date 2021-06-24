using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalReportBookAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDetailsDto
    {
        public int User_Id { get; set; }
        public string BloodGroup { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

    }
}