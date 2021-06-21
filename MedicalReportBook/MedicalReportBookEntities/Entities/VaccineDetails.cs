using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookEntities.Entities
{
   public class VaccineDetails
    {
        [Key]
        [ForeignKey("AppUser")]
        public int UserID { get; set; }
        [ForeignKey("Vaccine")]
        public int VaccineID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Vaccine Vaccine { get; set; }
    }
}
