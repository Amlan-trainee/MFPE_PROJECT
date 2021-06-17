using MedicalReportBookEntities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicalReportBookAPI.Models
{
   // [TypeConverter(typeof(ConsultancyReportDtoConverter))] //add this
    public class ConsultancyReportDto
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
        [Required]
        [Column(TypeName = "varchar(Max)")]
        public string Prescription { get; set; }
        [Required]
        public bool IsActive { get; set; }
       
        public int UId { get; set; }
       



    }
}