using MedicalReportBookAPI.Models;
using MedicalReportBookBLL;
using MedicalReportBookEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalReportBookAPI.Controllers
{
    public class AdminController : ApiController
    {
        private readonly AppUserService appUserService;
        public AdminController()
        {
            appUserService = new AppUserService();
        }
        protected override void Dispose(bool disposing)
        {
            appUserService.Dispose();
            base.Dispose(disposing);
        }
        [HttpPost]
        [Route("api/Admin/AddDrAdm")]
        public IHttpActionResult AddDoctorOrAdmin(AppUserDto obj)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var appUser = new AppUser();
                appUser.FirstName = obj.FirstName;
                appUser.MiddleName = obj.MiddleName;
                appUser.LastName = obj.LastName;
                appUser.Gender = obj.Gender;
                appUser.PhoneNumber = obj.PhoneNumber;
                appUser.Address = obj.Address;
                appUser.EmailId = obj.EmailId;
                appUser.UserType = obj.UserType;
                appUser.Password = obj.Password;
                appUser.ConfirmPassword = obj.ConfirmPassword;
                bool result = appUserService.AddUser(appUser);
                if (result)
                {
                    return Ok(HttpStatusCode.Created);

                }
                else
                {
                    return BadRequest("cannot add");
                }

            }

        }
    }
}
