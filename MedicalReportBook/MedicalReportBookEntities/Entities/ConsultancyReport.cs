﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookEntities.Entities
{
    /// <summary>
    /// Class to add ConsultancyReorts Table to MedicalReportBookModel Database
    /// </summary>
    public class ConsultancyReport
    {
        

        [Key]
        public int CR_Id { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string DoctorName { get; set; }
       
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofConsultancy { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string ClinicName { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string DiseaseName { get; set; }
        
        [Column(TypeName="varchar(Max)")]
        public string Prescription { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [ForeignKey("User")]       
        public int UId { get; set; }  //navigation property to Appuser
        public virtual AppUser User { get; set; }  

    }
}
