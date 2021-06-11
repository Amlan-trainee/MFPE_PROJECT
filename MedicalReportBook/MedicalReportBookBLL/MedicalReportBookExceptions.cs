using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookBLL
{
    public class MedicalReportBookExceptions:Exception
    {
        public MedicalReportBookExceptions() : base() { }
        public MedicalReportBookExceptions(string message) : base(message) { }
        public MedicalReportBookExceptions(string message,Exception innerException) : base(message, innerException) { }

    }
}
