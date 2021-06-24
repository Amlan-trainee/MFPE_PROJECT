using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookEntities.Entities
{
    /// <summary>
    /// This class helps to create a table for Doctor details.
    /// </summary>
   public class DoctorDetails
    {
        [Key]
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorId { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public virtual AppUser User { get; set; }
    }
}
