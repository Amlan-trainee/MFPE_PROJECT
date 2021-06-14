using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MedicalReportBookBLL;
using MedicalReportBookEntities.Entities;

namespace MedicalReportBookBLL.Tests
{
    [TestFixture]
   public class PatientService_Should
    {
        private PatientService service;
        [OneTimeSetUp]
        public void Init()
        {
            service = new PatientService();

        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            service.Dispose();
        }
        [Test]
        public void AddConsultancyReport()
        {
            var obj = new ConsultancyReport();
            obj.
        }

    }
}
