using MedicalReportBookEntities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicalReportBookAPI.Models
{
    public class LabReportEntityDto
    {
        [Key]
        public int Lr_Id { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string DoctorName { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string LabName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateofTest { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string TestName { get; set; }
        [Required]
        [Column(TypeName = "varchar(Max)")]
        public string LabReport { get; set; }
        [Required]
        public bool IsActive { get; set; }
        
        public int UID { get; set; }
        

    }
}