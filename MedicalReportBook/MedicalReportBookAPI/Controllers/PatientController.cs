using log4net;
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
        /// Action Method to Add User
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Statuscode 201 on sucessful execution else returns 415 Statuscode</returns>
        [HttpPost]
        [Route("api/AppUser/UserDetails")]
        public IHttpActionResult Post(UserDetailsDto obj)
        {
            try
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
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in User Registration");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in User Registration");
                log.Error(e.InnerException);
                return InternalServerError();
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
            try
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
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Add Consultancy");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Add Consultancy");
                log.Error(e.InnerException);
                return InternalServerError();
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
        public IHttpActionResult ViewConsultancyReportByDiseaseName([FromUri] int id, [FromUri] string DiseaseName)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest();
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
                            dtos.Add(new ConsultancyReportDto { CR_Id = obj.CR_Id, ClinicName = obj.ClinicName, DoctorName = obj.DoctorName, DateofConsultancy = obj.DateofConsultancy.Date, DiseaseName = obj.DiseaseName, Prescription = baseurl + obj.Prescription, IsActive = obj.IsActive });
                        }
                        return Ok(dtos);

                    }


                    return BadRequest();
                }
            }
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in View Consultancy Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in View Consultancy Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
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
            try
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
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Add Test Report");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Add Test Report");
                log.Error(e.InnerException);
                return InternalServerError();
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
        public IHttpActionResult ViewLabReportByTestName([FromUri] int id, [FromUri] string TestName)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest();
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
                            dtos.Add(new LabReportEntityDto { Lr_Id = obj.Lr_Id, TestName = obj.TestName, DoctorName = obj.DoctorName, DateofTest = obj.DateofTest.Date, LabName = obj.LabName, LabReport = baseurl + obj.LabReport, IsActive = obj.IsActive });
                        }
                        return Ok(dtos);

                    }
                    return BadRequest();


                }
            }
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in View Lab Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in View Lab Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Action method to Delete Lab Report
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TestName"></param>
        /// <param name="Lr_Id"></param>
        /// <returns>Statuscode 200 on sucessful execution else returns 415 Statuscode</returns>
        [HttpDelete]
        [Route("api/Patient/DeleteLabReport/{id}/{TestName}/{Lr_Id}")]
        public IHttpActionResult DeleteLabReportByTestName([FromUri] int id, [FromUri] string TestName, [FromUri] int Lr_Id)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest();
                }
                else
                {
                    var objs = patientService.DeleteLabReportByTestName(id, TestName, Lr_Id);
                    if (objs)
                    {
                        return Ok("Deleted Successfully");
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
            }
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Delete Lab Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Delete Lab Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Action method to Delete Consultancy Report
        /// </summary>
        /// <param name="id"></param>
        /// <param name="DiseaseName"></param>
        /// <param name="CR_Id"></param>
        /// <returns>Statuscode 200 on sucessful execution else returns 415 Statuscode</returns>
        [HttpDelete]
        [Route("api/Patient/DeleteConsultancyReport/{id}/{DiseaseName}/{CR_Id}")] 
        public IHttpActionResult DeleteConsultancyReportByTestName([FromUri] int id, [FromUri] string DiseaseName, [FromUri] int CR_Id)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest();
                }
                else
                {
                    var objs = patientService.DeleteConsultancyReportByDiseaseName(id, DiseaseName, CR_Id);
                    if (objs)
                    {
                        return Ok("Deleted Successfully");
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
            }
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Delete Consultancy Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Delete Consultancy Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
        }
        /// <summary>
        /// Action Method to Lock and Unlock Consultancy Report
        /// </summary>
        /// <param name="lockandUnlockDto"></param>
        /// <returns>Statuscode 200 on sucessful execution else returns 415 Statuscode</returns>
        [HttpPut]
        [Route("api/Patient/LockUnlockCrReport")]
        public IHttpActionResult LockUnlockConsultancyReport(LockandUnlockDto lockandUnlockDto)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var result = patientService.AccessPermissionForConsultancyReport(lockandUnlockDto.Report_Id, lockandUnlockDto.IsActive);
                    if (result)
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Lock/Unlock Consultancy Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Lock/Unlock Consultancy Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
        }

        /// <summary>
        /// Action Method to Lock and Unlock Lab Report
        /// </summary>
        /// <param name="lockandUnlockDto"></param>
        /// <returns>Statuscode 200 on sucessful execution else returns 415 Statuscode</returns>
        [HttpPut]
        [Route("api/Patient/LockUnlockLrReport")]
        public IHttpActionResult LockUnlockLabReport(LockandUnlockDto lockandUnlockDto)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var result = patientService.AccessPermissionForLabReport(lockandUnlockDto.Report_Id, lockandUnlockDto.IsActive);
                    if (result)
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            catch (MedicalReportBookExceptions e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Lock/Unlock Lab Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
            catch (Exception e)
            {
                ILog log = LogManager.GetLogger(typeof(PatientController));
                log.Info("Exception occured in Lock/Unlock Lab Report By User");
                log.Error(e.InnerException);
                return InternalServerError();
            }
        }
    }
}
