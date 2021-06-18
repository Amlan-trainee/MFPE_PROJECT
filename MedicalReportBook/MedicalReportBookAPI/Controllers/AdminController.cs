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
    /// <summary>
    /// Controller class to work with Admin service and Appuser Service
    /// </summary>
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
        /// <summary>
        /// Action Method for a new doctor or admin to database by admin
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> Statuscode 201 on sucessful execution else returns 415 Statuscode </returns>
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

            //Harish
        [HttpDelete]
        [Route("api/Admin/RemoveDoctor")]
        public HttpResponseMessage DeleteDoctorbyEmail([FromUri]string EmailId)
        {
            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                bool result = appUserService.DeleteDoctor(EmailId);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
        }

    }
}
