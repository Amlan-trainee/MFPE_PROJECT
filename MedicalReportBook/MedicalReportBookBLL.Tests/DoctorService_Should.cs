using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalReportBookBLL;
using MedicalReportBookEntities.Entities;

namespace MedicalReportBookBLL.Tests
{
    /// <summary>
    /// test class for DoctorService
    /// </summary>
    [TestFixture]
    public class DoctorService_Should
    {
        private DoctorService service;
        [OneTimeSetUp]
        public void Init()
        {
            service = new DoctorService();

        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            service.Dispose();
        }
        /// <summary>
        /// Test method to test the  ViewConsultancyReportOfPatient of DoctorService
        /// </summary>
        [Test]
        public void ViewConsultancyReportOfPatient()
        {
            var EmilId = "abcd3@gmil.com";
            var DiseaseName = "Cold";
            var result = service.ViewConsultancyReportOfPatient(EmilId, DiseaseName);
            CollectionAssert.IsNotEmpty(result);
        }
        /// <summary>
        /// Test method for the ViewLabReportOfPatient of DoctorService
        /// </summary>
        [Test]
        public void ViewLabReportOfPatient()
        {

            var EmilId = "abcd3@gmil.com";
            var DiseaseName = "Ultrasound";
            var result = service.ViewLabReportOfPatient(EmilId, DiseaseName);
            CollectionAssert.IsNotEmpty(result);
        }

        [Test]
        public void ChangePassword()
        {
            /*AppUser app = new AppUser();
            app.FirstName = "Kumar";
            app.MiddleName = "Raj";
            app.LastName = "J";
            app.Gender = "Male";
            app.PhoneNumber = 3456789021;
            app.Address = "abc";
            app.EmailId = "kumar@gmail.com";
            app.UserType = "Doctor";
            app.Password = "Doctor@123";*/
            var Id = 4;
            var Password = "Doctor@123";
            var result = service.ChangePassword(Id,Password);
            var expexted = true;
            Assert.AreEqual(expexted, result);
        }

        [Test]
        public void UpdateDoctorDetails()
        {
            var obj = new DoctorDetails();
            obj.DoctorId = 3;
            obj.Specialization = "ophthalmology";
            obj.Qualification = "MBBS";
            var result = service.AddDoctorDetails(obj);
            var expexted = true;
            Assert.AreEqual(expexted, result);
        }
    }
}
