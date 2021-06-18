using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MedicalReportBookBLL;
using MedicalReportBookEntities.Entities;

namespace MedicalReportBookBLL.Tests
{/// <summary>
/// Test class for AppUserService 
/// </summary>
    [TestFixture]
   public class AppUserService_Should
    { 
        private AppUserService service;
        [OneTimeSetUp]
        public void Init()
        {
            service = new AppUserService();

        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            service.Dispose();
        }
        /// <summary>
        /// Test Method for Adding user method of AppUserService
        /// </summary>
        [Test]
        public void AddUser()
        {
            var obj = new AppUser();
            obj.FirstName = "jojo1";
            obj.MiddleName = "blitz2";
            obj.LastName = "jose2";
            obj.Gender = "Male";
            obj.PhoneNumber = 1234444890;
            obj.Address = "123333st";
            obj.EmailId = "doc@gmail.com";
            obj.UserType = "Doctor";
            obj.Password = "jojojose";
            obj.ConfirmPassword = "jojojose";
            bool result = service.AddUser(obj);

            Assert.AreEqual(true, result);

        }
        /// <summary>
        /// Test method for testing Login method of AppUserService
        /// </summary>
        [Test]
        public void CheckCredentialsForLogin()
        {
            
            var EmailId = "abc@gmil.com";
            var Password = "jojojose";           
            var result = service.Login(EmailId, Password,out int id);
            var expectedUserType = "User";
            var expectedUserId = 1;
            Assert.AreEqual(expectedUserType, result);
            Assert.AreEqual(expectedUserId, id);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void DeleteDoctor()
        {
            var EmailId = "doc@gmail.com";
            var UserId = 0;
            var actual = service.DeleteDoctor(EmailId,UserId);
            var expected = true;
            Assert.That(expected, Is.EqualTo(actual));
        }
       
    }
}
