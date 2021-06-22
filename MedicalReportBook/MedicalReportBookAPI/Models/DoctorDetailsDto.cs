using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalReportBookAPI.Models
{
    public class DoctorDetailsDto
    {
        public int DoctorId { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
    }
}