﻿using System;
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
    /// <summary>
    /// Controller class for working with AppUser Service 
    /// </summary>
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
        /// <summary>
        /// Action Method for adding a new user to database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Statuscode 201 on sucessful execution else returns 415 Statuscode</returns>
        [HttpPost]
        [Route("api/AppUser/Registration")]
        public IHttpActionResult Post(AppUserDto obj)
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
        /// Action method for checking credentials of user and logging him into his profile
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns>user type and user id on sucessful execution else returns 415 BadRequest Stattus code</returns>
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
                var result = appUserService.Login(appUser.EmailId,appUser.Password,out int id);
                if (result!=null && result!="")
                {
                    return Ok(new {Result=result ,Id=id});

                }
                else
                {
                    return BadRequest("Login Failed,wrong EmailId or Password");
                }

            }

        }

       
    }
}
