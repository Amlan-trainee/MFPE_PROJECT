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
            obj.ClinicName = "aiims";
            obj.DoctorName = "Dr.miraj";
            obj.DateofConsultancy = new DateTime(2021,04,04);
            obj.DiseaseName = "Stomach Ache";
            obj.Prescription = "need to put pics";
            obj.IsActive = false;
            obj.UId = 1;
            var result = service.AddConsultancyReport(obj);
            var expected = true;
            Assert.AreEqual(expected, result);

        }
        [Test]
        public void ViewConsultancyReportByDiseaseName()
        {
            var DiseaseName = "Cold";
            var result = service.ViewConsultancyReportByDiseaseName(DiseaseName);        
            CollectionAssert.IsNotEmpty(result);
        }

    }
}
