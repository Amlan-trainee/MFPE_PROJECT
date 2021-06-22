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

         /// <summary>
         /// 
         /// </summary>
         /// <param name="EmailId"></param>
         /// <returns></returns>
        [HttpDelete]
        [Route("api/Admin/RemoveDoctor/{EmailId}/{UserId}")]
        public HttpResponseMessage DeleteDoctorbyEmail([FromUri]string EmailId,[FromUri] int UserId)
        {
            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                bool result = appUserService.DeleteDoctor(EmailId,UserId);
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

        [HttpGet]
        [Route("api/Admin/ViewAllDoctors")]
        public IHttpActionResult ViewAllDoctors()
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            else
            {
                var objs = appUserService.ViewDoctor();
                if (objs != null && objs.Count != 0)
                {
                    List<AppUserDto> dtos = new List<AppUserDto>();
                    foreach (var obj in objs)
                    {
                        dtos.Add(new AppUserDto {UserId=obj.UserId, FirstName=obj.FirstName,MiddleName=obj.MiddleName,LastName=obj.LastName,PhoneNumber=obj.PhoneNumber,EmailId=obj.EmailId,UserType=obj.UserType });
                    }
                    return Ok(dtos);

                }
                else
                {
                    return BadRequest();
                }
            }

        }
    }
}
