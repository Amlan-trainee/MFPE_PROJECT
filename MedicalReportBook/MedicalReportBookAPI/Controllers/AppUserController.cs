using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using MedicalReportBookBLL;
using MedicalReportBookAPI.Models;
using MedicalReportBookEntities;
using MedicalReportBookEntities.Entities;

namespace MedicalReportBookAPI.Controllers
{
    public class AppUserController : ApiController
    {
        private readonly AppUserService appUserService;
        public AppUserController()
        {
            appUserService = new AppUserService();
        }
        protected override void Dispose(bool disposing)
        {
            appUserService.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("api/AppUser/Registration")]
        public IHttpActionResult Post(AppUser obj)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                bool result = appUserService.AddUser(obj);
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
        [HttpPost]
        [Route("api/AppUser/Login")]
        public IHttpActionResult Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var appUser = new AppUser();
                if (userLoginDto == null)
                {
                    return BadRequest("Invalid email/password");
                }
                appUser.EmailId = userLoginDto.EmailId;
                appUser.Password = userLoginDto.Password;
                bool result = appUserService.Login(appUser.EmailId,appUser.Password);
                if (result)
                {
                    return Ok("Login Sucessful");

                }
                else
                {
                    return BadRequest("Login Failed");
                }

            }

        }

    }
}
