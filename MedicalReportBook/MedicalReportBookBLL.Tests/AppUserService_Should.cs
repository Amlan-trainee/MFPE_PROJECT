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
            obj.EmailId = "abcdef@gmail.com";
            obj.UserType = "User";
            obj.Password = "jojojose";
            obj.ConfirmPassword = "jojojose";
            bool result = service.AddUser(obj);

            Assert.AreEqual(true, result);

        }
        [Test]
        public void CheckCredentialsForLogin()
        {
            
            var EmailId = "abc@gmil.com";
            var Password = "jojojose";
            var result = service.Login(EmailId, Password);
            var expected = true;
            Assert.AreEqual(expected, result);
        }
       
    }
}
