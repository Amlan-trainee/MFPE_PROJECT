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

        [HttpGet]
        [Route("api/Doctor/ViewConsultancyReport/{EmailId}/{DiseaseName}")]
        public HttpResponseMessage ViewConsultancyReportOfPatient([FromUri] string EmailId, [FromUri] string DiseaseName)
        {

            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {


                var objs = doctorService.ViewConsultancyReportOfPatient(EmailId, DiseaseName);
                if (objs != null)
                {
                    List<ConsultancyReportDto> dtos = new List<ConsultancyReportDto>();
                    foreach (var obj in objs)
                    {
                        dtos.Add(new ConsultancyReportDto { ClinicName = obj.ClinicName, DoctorName = obj.DoctorName, DateofConsultancy = obj.DateofConsultancy, DiseaseName = obj.DiseaseName, Prescription = obj.Prescription, IsActive = obj.IsActive});
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }


                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }
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
                if (objs != null)
                {
                    List<LabReportEntityDto> dtos = new List<LabReportEntityDto>();
                    foreach (var obj in objs)
                    {
                        dtos.Add(new LabReportEntityDto { TestName = obj.TestName, DoctorName = obj.DoctorName, DateofTest = obj.DateofTest.Date, LabName = obj.LabName, LabReport = obj.LabReport, IsActive = obj.IsActive });//Not retoring UserId as output
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, dtos);

                }


                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }



    }
}
