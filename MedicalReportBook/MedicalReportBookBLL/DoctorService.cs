using MedicalReportBookEntities;
using MedicalReportBookEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalReportBookBLL
{
   public class DoctorService
    {
        private readonly MedicalReportBookContext context;

        public DoctorService()
        {
            context = new MedicalReportBookContext();
        }
        public void Dispose()
        {
            context.Dispose();

        }
        public List<ConsultancyReport> ViewConsultancyReportOfPatient(string EmailId, string DiseaseName) //give id (input it) include ,,image 
        {
            try
            {
                var check = (from user in context.appUsers
                            where user.EmailId == EmailId
                            select user.UserId).FirstOrDefault();
                if(check!=0)
                {
                    var query = from obj in context.ConsultancyReports
                                where obj.DiseaseName == DiseaseName && obj.IsActive == true && obj.UId==check
                                select obj;
                    return query.ToList();

                }
                else
                {
                    return null;

                }

               
            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Not Found", e);

            }


        }
        public List<LabReportEntity> ViewLabReportOfPatient(string EmailId, string TestName) //give id (input it) include ,,image 
        {
            try
            {
                var check = (from user in context.appUsers
                             where user.EmailId == EmailId
                             select user.UserId).FirstOrDefault();
                if (check != 0)
                {
                    var query = from obj in context.LabReportEntities
                                where obj.TestName == TestName && obj.IsActive == true && obj.UID == check
                                select obj;
                    return query.ToList();

                }
                else
                {
                    return null;

                }
            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("not found", e);

            }


        }

    }
}
