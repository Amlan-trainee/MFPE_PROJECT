﻿using MedicalReportBookAPI.Models;
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
        public IHttpActionResult AddConsultancyReport(ConsultancyReportDto consultancyReportDto)
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
                consultancyReport.DateofConsultancy = consultancyReportDto.DateofConsultancy;
                consultancyReport.DiseaseName = consultancyReportDto.DiseaseName;
                consultancyReport.Prescription = consultancyReportDto.Prescription;
                consultancyReport.IsActive = consultancyReportDto.IsActive;
                consultancyReportDto.UId = consultancyReportDto.UId;

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
        [Route("api/Patient/ViewConsultancyReport/{DiseaseName}")]
        public HttpResponseMessage ViewConsultancyReportByDiseaseName([FromUri]string DiseaseName)
        {
            //var result = patientService.ViewConsultancyReportByDiseaseName(DiseaseName);
            //if (result == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(result);
            //}
            if(ModelState.IsValid==false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else {
                var objs = patientService.ViewConsultancyReportByDiseaseName(DiseaseName);

                List<ConsultancyReportDto> dtos = new List<ConsultancyReportDto>();
                foreach (var obj in objs)
                {
                    dtos.Add(new ConsultancyReportDto { ClinicName = obj.ClinicName, DoctorName = obj.DoctorName, DateofConsultancy = obj.DateofConsultancy, DiseaseName = obj.DiseaseName, Prescription = obj.Prescription, IsActive = obj.IsActive });
                }
                return Request.CreateResponse(HttpStatusCode.OK, dtos);
            }
           

        }
    }
}
