using MedicalReportBookEntities;
using MedicalReportBookEntities.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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
               
                context.ConsultancyReports.Add(consultancyReport);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;
        
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Uploading prescription... failed", e);

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
                throw new MedicalReportBookExceptions("Not Found", e);

            }


        }
        public bool AddLabReport(LabReportEntity labReportEntity)
        {
            try
            {

                context.LabReportEntities.Add(labReportEntity);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;

            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Uploading labreport... failed", e);

            }

        }
        public List<LabReportEntity> ViewLabReportByTestName(int id, string TestName) //give id (input it) include ,,image 
        {
            try
            {
                var query = (from obj in context.LabReportEntities
                             where obj.TestName == TestName && obj.UID == id
                             select obj).Include(user => user.User);
                return query.ToList();
            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("not found", e);

            }


        }

    }
}
