using MedicalReportBookEntities;
using MedicalReportBookEntities.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalReportBookBLL
{
  public class PatientService
    {
        private readonly MedicalReportBookContext context;

        public PatientService()
        {
            context = new MedicalReportBookContext();
        }
        public void Dispose()
        {
            context.Dispose();

        }
        public bool AddConsultancyReport(ConsultancyReport consultancyReport )
        {
            try
            {
                //string sPath = "";
                //sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Image/");
                //System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                //System.Web.HttpPostedFile hpf = hfc[iCnt];
                //if (hpf.ContentLength > 0)
                //{
                //    string FileName = (Path.GetFileName(hpf.FileName));
                //    if (!File.Exists(sPath + FileName))
                //    {
                //        // SAVE THE FILES IN THE FOLDER.  
                //        hpf.SaveAs(sPath + FileName);
                        
                //        consultancyReport.Prescription = FileName;
                //        context.ConsultancyReports.Add();
                //        int rows = context.SaveChanges();
                //        if (rows == 1)
                //            return Ok();

                //    }
                //}

                context.ConsultancyReports.Add(consultancyReport);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;


                //-------------------------------------------using System;
                //using System.Collections.Generic;
                //using System.IO;
                //using System.Linq;
                //using System.Net;
                //using System.Net.Http;
                //using System.Web.Http;

                //string sPath = "";
                //sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Image/");


                //System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

                //for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                //{
                //    System.Web.HttpPostedFile hpf = hfc[iCnt];
                //    if (hpf.ContentLength > 0)
                //    {
                //        string FileName = (Path.GetFileName(hpf.FileName));
                //        if (!File.Exists(sPath + FileName))
                //        {
                //            // SAVE THE FILES IN THE FOLDER.  
                //            hpf.SaveAs(sPath + FileName);
                //            Image obj = new Image();
                //            obj.ImageUp = FileName;
                //            context.images.Add(obj);
                //            int rows = context.SaveChanges();
                //            if (rows == 1)
                //                return Ok();

                //        }
                //    }
                //}

                //return BadRequest("Upload Failed");
                //---------------------------------------------------

            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Registration failed", e);

            }

        }
        public List<ConsultancyReport> ViewConsultancyReportByDiseaseName(int id ,string DiseaseName) //give id (input it) include ,,image 
        {
            try 
            {
                var query = (from obj in context.ConsultancyReports
                            where obj.DiseaseName == DiseaseName && obj.UId==id
                            select obj).Include(user=>user.User);
                return query.ToList();
            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Registration failed", e);

            }


        }

    }
}
