﻿using MedicalReportBookAPI.Models;
using MedicalReportBookBLL;
using MedicalReportBookEntities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MedicalReportBookAPI.Controllers
{
    /// <summary>
    /// Controller class to work with Patient service
    /// </summary>
    public class PatientController : ApiController
    {
        private readonly PatientService patientService;
        public PatientController()
        {
            patientService = new PatientService();
        }
        protected override void Dispose(bool disposing)
        {
            patientService.Dispose();
            base.Dispose(disposing);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/AppUser/UserDetails")]
        public IHttpActionResult Post(UserDetailsDto obj)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var userDetails = new UserDetails();
                userDetails.User_Id = obj.User_Id;
                userDetails.Weight = obj.Weight;
                userDetails.Height = obj.Height;
                userDetails.BloodGroup = obj.BloodGroup;
                bool result = patientService.AddUserDetails(userDetails);
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
        /// Method to add the Consultancy Report
        /// </summary>
        /// <param name="consultancyReportDto"></param>
        /// <returns>Statuscode 201 on sucessful execution else returns 415 Statuscode</returns>
        [HttpPost]
        [Route("api/Patient/AddConsultancyReport")]
        public IHttpActionResult AddConsultancyReport(ConsultancyReportDto consultancyReportDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var consultancyReport = new ConsultancyReport();
                consultancyReport.ClinicName = consultancyReportDto.ClinicName;
                consultancyReport.DoctorName = consultancyReportDto.DoctorName;
                consultancyReport.DateofConsultancy = consultancyReportDto.DateofConsultancy.Date;
                consultancyReport.DiseaseName = consultancyReportDto.DiseaseName;
                consultancyReport.Prescription = consultancyReportDto.Prescription;
                consultancyReport.IsActive = consultancyReportDto.IsActive;
                consultancyReport.UId = consultancyReportDto.UId;
                var uploadedImagePath = HttpContext.Current.Server.MapPath("~/Images/");
                consultancyReportDto.File.SaveAs(uploadedImagePath + consultancyReportDto.Prescription);

                var result = patientService.AddConsultancyReport(consultancyReport);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Adding Prescription Failed");
                }

            }
        }

        /// <summary>
        /// Method to View the Counsultancy Report by passing the Disease Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="DiseaseName"></param>
        /// <returns>List of Counsultancy Report</returns>
        [HttpGet]
        [Route("api/Patient/ViewConsultancyReport/{id}/{DiseaseName}")]
        public HttpResponseMessage ViewConsultancyReportByDiseaseName([FromUri] int id, [FromUri] string DiseaseName)
        {

            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {


                var objs = patientService.ViewConsultancyReportByDiseaseName(id, DiseaseName);
                if (objs != null && objs.Count != 0)
                {
                    List<ConsultancyReportDto> dtos = new List<ConsultancyReportDto>();
                    var baseurl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Host}:{Request.RequestUri.Port}/Images/";
                    foreach (var obj in objs)
                    {
                        dtos.Add(new ConsultancyReportDto {CR_Id=obj.CR_Id, ClinicName = obj.ClinicName, DoctorName = obj.DoctorName, DateofConsultancy = obj.DateofConsultancy.Date, DiseaseName = obj.DiseaseName, Prescription = baseurl + obj.Prescription, IsActive = obj.IsActive });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }


                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }


        /// <summary>
        /// Method to add the Lab Report
        /// </summary>
        /// <param name="labReportEntityDto"></param>
        /// <returns>Statuscode 201 on sucessful execution else returns 415 Statuscode</returns>

        [HttpPost]
        [Route("api/Patient/AddTestReport")]
        public IHttpActionResult AddTestReport(LabReportEntityDto labReportEntityDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var labReportEntity = new LabReportEntity();
                labReportEntity.LabName = labReportEntityDto.LabName;
                labReportEntity.DoctorName = labReportEntityDto.DoctorName;
                labReportEntity.DateofTest = labReportEntityDto.DateofTest.Date;
                labReportEntity.TestName = labReportEntityDto.TestName;
                labReportEntity.LabReport = labReportEntityDto.LabReport;
                labReportEntity.IsActive = labReportEntityDto.IsActive;
                labReportEntity.UID = labReportEntityDto.UID;
                var uploadedImagePath = HttpContext.Current.Server.MapPath("~/Images/");
                labReportEntityDto.File.SaveAs(uploadedImagePath + labReportEntityDto.LabReport);

                var result = patientService.AddLabReport(labReportEntity);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Adding LabReport Failed");
                }

            }
        }

        /// <summary>
        /// Method to View the Lab Report by passing Test Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TestName"></param>
        /// <returns>List of Lab Report</returns>
        [HttpGet]
        [Route("api/Patient/ViewLabReport/{id}/{TestName}")]
        public HttpResponseMessage ViewLabReportByTestName([FromUri] int id, [FromUri] string TestName)
        {

            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {


                var objs = patientService.ViewLabReportByTestName(id, TestName);
                var baseurl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Host}:{Request.RequestUri.Port}/Images/";
                if (objs != null && objs.Count != 0)
                {
                    List<LabReportEntityDto> dtos = new List<LabReportEntityDto>();
                    foreach (var obj in objs)
                    {
                        dtos.Add(new LabReportEntityDto { Lr_Id=obj.Lr_Id, TestName = obj.TestName, DoctorName = obj.DoctorName, DateofTest = obj.DateofTest.Date, LabName = obj.LabName, LabReport = baseurl + obj.LabReport, IsActive = obj.IsActive });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);


            }


        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="TestName"></param>
       /// <param name="Lr_Id"></param>
       /// <returns></returns>
        [HttpDelete]
        [Route("api/Patient/DeleteLabReport/{id}/{TestName}/{Lr_Id}")]
        public HttpResponseMessage DeleteLabReportByTestName([FromUri] int id, [FromUri] string TestName, [FromUri] int Lr_Id)
        {
            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var objs = patientService.DeleteLabReportByTestName(id, TestName, Lr_Id);
                if (objs)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="DiseaseName"></param>
        /// <param name="CR_Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Patient/DeleteConsultancyReport/{id}/{DiseaseName}/{CR_Id}")] 
        public HttpResponseMessage DeleteConsultancyReportByTestName([FromUri] int id, [FromUri] string DiseaseName, [FromUri] int CR_Id)
        {
            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var objs = patientService.DeleteConsultancyReportByDiseaseName(id, DiseaseName,CR_Id);
                if (objs)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
        }
        [HttpPut]
        [Route("api/Patient/LockUnlockCrReport/{CR_Id}")]
        public IHttpActionResult LockUnlockConsultancyReport(int CR_Id)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = patientService.AccessPermissionForConsultancyReport(CR_Id);
                if(result)
                {
                    return Ok();
                }
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("api/Patient/LockUnlockLrReport/{Lr_Id}")]
        public IHttpActionResult LockUnlockLabReport(int Lr_Id)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = patientService.AccessPermissionForLabReport(Lr_Id);
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
        }

    }
}
