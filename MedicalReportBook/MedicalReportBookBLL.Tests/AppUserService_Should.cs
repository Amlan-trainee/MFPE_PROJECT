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
            obj.FirstName = "jojo";
            obj.MiddleName = "blitz";
            obj.LastName = "jose";
            obj.Gender = "Male";
            obj.PhoneNumber = 1234567890;
            obj.Address = "123st";
            obj.EmailId = "abc@gmail.com";
            obj.UserType = "User";
            obj.Password = "jojojose";
            obj.ConfirmPassword = "jojojose";
            bool result=service.AddUser(obj);
            
            Assert.AreEqual(true,result);

        }
       
    }
}
