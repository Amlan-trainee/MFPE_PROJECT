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
    /// <summary>
    /// Test Class for PatientService
    /// </summary>
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
        /// <summary>
        /// Test Method for testing AddConsultancyReport method of Patient class
        /// </summary>
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
        /// <summary>
        /// Test Method for testing ViewConsultancyReportByDiseaseName method of Patient class
        /// </summary>
        [Test]
        public void ViewConsultancyReportByDiseaseName()
        {
            var DiseaseName = "Cold";
            var id = 3;
            var result = service.ViewConsultancyReportByDiseaseName(id,DiseaseName);        
            CollectionAssert.IsNotEmpty(result);
        }
        /// <summary>
        /// Test Method for testing AddLabReport method of Patient class
        /// </summary>
        [Test]
        public void AddLabReport()
        {
            var obj = new LabReportEntity();
            obj.LabName = "apolo labs";
            obj.DoctorName = "Dr.miraj";
            obj.DateofTest = new DateTime(2021, 04, 04);
            obj.TestName = "xray";
            obj.LabReport = "need to put pics";
            obj.IsActive = false;
            obj.UID = 1;
            var result = service.AddLabReport(obj);
            var expected = true;
            Assert.AreEqual(expected, result);

        }
        /// <summary>
        /// Test Method for testing ViewLabReportByTestName method of Patient class
        /// </summary>
        [Test]
        public void ViewLabReportByTestName()
        {
            var TestName = "xray";//add 'xray' to pass
            var id = 1;
            var result = service.ViewLabReportByTestName(id, TestName);
            CollectionAssert.IsNotEmpty(result);
        }

    }
}
