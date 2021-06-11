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
                    return Ok("Registration Sucessful");

                }
                else
                {
                    return BadRequest("cannot add");
                }

            }

        }
        [HttpPost]
        public IHttpActionResult Post(string EmialId, string Password)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                bool result = appUserService.Login(EmialId, Password);
                if (result)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest("cannt add");
                }

            }

        }

    }
}
