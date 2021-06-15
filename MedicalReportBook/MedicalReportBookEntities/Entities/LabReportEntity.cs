using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookEntities.Entities
{
    public class LabReportEntity
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
        [ForeignKey("User")]
        public int UID { get; set; }
        public virtual AppUser User { get; set; }

    }
}
