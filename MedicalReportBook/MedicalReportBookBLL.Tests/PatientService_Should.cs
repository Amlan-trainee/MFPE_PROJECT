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

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void DeleteLabReportByTestName()
        {
            var TestName = "xray";
            var id = 1;
            var Lr_Id = 1003;
            var actual = service.DeleteLabReportByTestName(id, TestName,Lr_Id);
            var expected = true;
            Assert.That(expected, Is.EqualTo(actual));
        }

       /// <summary>
       /// 
       /// </summary>
        [Test]
        public void DeleteConsultancyReportByDiseasetName()
        {
            var DiseaseName = "Stomach Ache";
            var id = 1;
            var CR_Id = 10;
            var actual = service.DeleteConsultancyReportByDiseaseName(id, DiseaseName,CR_Id);
            var expected = true;
            Assert.That(expected, Is.EqualTo(actual));
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void AccessPermissionForConsultancyRepoort()
        {
            var CR_Id = 7;
            var actual = service.AccessPermissionForConsultancyReport(CR_Id);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void AccessPermissionForLabRepoort()
        {
            var Lr_Id = 1;
            var actual = service.AccessPermissionForLabReport(Lr_Id);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AddUserDetails()
        {
            var obj = new UserDetails();
            obj.BloodGroup = "O+";
            obj.Height = 1.83;
            obj.Weight = 72.5;
            obj.User_Id = 1;
            var actual = service.AddUserDetails(obj);
            var expected = true;
            Assert.That(expected, Is.EqualTo(actual));
        }


    }
}
