using MedicalReportBookAPI.Models;
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
        [HttpPost]
        [Route("api/Patient/AddConsultancyReport")]
        public IHttpActionResult AddConsultancyReport(ConsultancyReportDto consultancyReportDto)//add Converter class obj here
        {
            if(ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var consultancyReport = new ConsultancyReport(); 
                consultancyReport.ClinicName = consultancyReportDto.ClinicName;
                consultancyReport.DoctorName = consultancyReportDto.DoctorName;
                consultancyReport.DateofConsultancy= consultancyReportDto.DateofConsultancy.Date;
                consultancyReport.DiseaseName = consultancyReportDto.DiseaseName;
                consultancyReport.Prescription = consultancyReportDto.Prescription;
                consultancyReport.IsActive = consultancyReportDto.IsActive;
                consultancyReport.UId = consultancyReportDto.UId;
                var uploadedImagePath = HttpContext.Current.Server.MapPath("~/Images/");
                consultancyReportDto.File.SaveAs(uploadedImagePath + consultancyReportDto.Prescription);

                var result=  patientService.AddConsultancyReport(consultancyReport);
                if(result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Adding Prescription Failed");
                }

            }
        }
        [HttpGet]
        [Route("api/Patient/ViewConsultancyReport/{id}/{DiseaseName}")]
        public HttpResponseMessage ViewConsultancyReportByDiseaseName([FromUri]int id,[FromUri]string DiseaseName) 
        {
           
            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {


                var objs = patientService.ViewConsultancyReportByDiseaseName(id,DiseaseName);
                if(objs!=null && objs.Count != 0)
                {
                    List<ConsultancyReportDto> dtos = new List<ConsultancyReportDto>();
                    var baseurl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Host}:{Request.RequestUri.Port}/Images/";
                    foreach (var obj in objs)
                    {
                        dtos.Add(new ConsultancyReportDto { ClinicName = obj.ClinicName, DoctorName = obj.DoctorName, DateofConsultancy = obj.DateofConsultancy.Date, DiseaseName = obj.DiseaseName, Prescription = baseurl+obj.Prescription, IsActive = obj.IsActive});//Not retoring UserId as output
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }

               
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }




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
                        dtos.Add(new LabReportEntityDto { TestName = obj.TestName, DoctorName = obj.DoctorName, DateofTest = obj.DateofTest.Date, LabName = obj.LabName, LabReport =baseurl+ obj.LabReport, IsActive = obj.IsActive});//Not retoring UserId as output
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);


            }


        }

    }
}
