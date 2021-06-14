using MedicalReportBookEntities;
using MedicalReportBookEntities.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                throw new MedicalReportBookExceptions("Registration failed", e);

            }

        }
        public List<ConsultancyReport> ViewConsultancyReportByDiseaseName(string DiseaseName)
        {
            try 
            {
                var query = from obj in context.ConsultancyReports
                            where obj.DiseaseName == DiseaseName
                            select obj;
                return query.ToList();
            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Registration failed", e);

            }


        }

    }
}
