using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookEntities.Entities
{
    public class Vaccine
    {
        [Key]
        public int VaccineId { get; set; }
        public string VaccineName { get; set; }
        public virtual ICollection<VaccineDetails> VaccineDetails{get;set;}
    }
}
