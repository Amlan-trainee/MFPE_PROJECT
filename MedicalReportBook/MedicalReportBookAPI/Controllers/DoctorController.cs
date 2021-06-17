using MedicalReportBookAPI.Models;
using MedicalReportBookBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalReportBookAPI.Controllers
{
    /// <summary>
    /// Controller class to work with Doctor Service
    /// </summary>
    public class DoctorController : ApiController
    {

        private readonly DoctorService doctorService;
        public DoctorController()
        {
            doctorService = new DoctorService();
        }
        protected override void Dispose(bool disposing)
        {
            doctorService.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Method to View the Counsultancy Report by passing the Disease Name and EmailId
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="DiseaseName"></param>
        /// <returns>List of Counsultancy Report</returns>

        [HttpGet]
        [Route("api/Doctor/ViewConsultancyReportOfPatient/{EmailId}/{DiseaseName}")]
        public HttpResponseMessage ViewConsultancyReportOfPatient([FromUri] string EmailId, [FromUri] string DiseaseName)
        {

            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {


                var objs = doctorService.ViewConsultancyReportOfPatient(EmailId, DiseaseName);
                if (objs != null && objs.Count!=0)
                {
                    List<ConsultancyReportDto> dtos = new List<ConsultancyReportDto>();
                    var baseurl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Host}:{Request.RequestUri.Port}/Images/";
                    foreach (var obj in objs)
                    {
                        dtos.Add(new ConsultancyReportDto { ClinicName = obj.ClinicName, DoctorName = obj.DoctorName, DateofConsultancy = obj.DateofConsultancy, DiseaseName = obj.DiseaseName, Prescription = baseurl+obj.Prescription, IsActive = obj.IsActive});
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }


                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }

        /// <summary>
        /// Method to View the Lab Report by passing the Test Name and EmailId
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="TestName"></param>
        /// <returns>List of Counsultancy Report</returns>
        [HttpGet]
        [Route("api/Doctor/ViewLabReportOfPatient/{EmailId}/{TestName}")]
        public HttpResponseMessage ViewLabReportOfPatient([FromUri] string EmailId, [FromUri] string TestName)
        {
          
            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {


                var objs = doctorService.ViewLabReportOfPatient(EmailId, TestName);
                if (objs != null && objs.Count != 0)
                {
                    List<LabReportEntityDto> dtos = new List<LabReportEntityDto>();
                    var baseurl = $"{Request.RequestUri.Scheme}://{Request.RequestUri.Host}:{Request.RequestUri.Port}/Images/";
                    foreach (var obj in objs)
                    {
                        dtos.Add(new LabReportEntityDto { TestName = obj.TestName, DoctorName = obj.DoctorName, DateofTest = obj.DateofTest.Date, LabName = obj.LabName, LabReport = baseurl+obj.LabReport, IsActive = obj.IsActive });//Not retoring UserId as output
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }


                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }



    }
}
