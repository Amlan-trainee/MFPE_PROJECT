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
    /// <summary>
    /// MedicalReportService to interact with MedicalReportBookModel database and do CRUD operation
    /// </summary>
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
        /// <summary>
        /// This method allows the doctor to see the consultancy report of user that are left unlocked by the user.
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="DiseaseName"></param>
        /// <returns> list of consultancy report based on disease name and emailid of a particular user or else return null if the method fails</returns>
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
                    if(query!=null)
                    return query.ToList();
                    return null;

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
        /// <summary>
        /// This method allows the doctor to see the labreport of user that are left unlocked by the user.
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="TestName"></param>
        /// <returns>list of lab report based on test name and emailid of a particular user or else return null if the method fails</returns>
        public List<LabReportEntity> ViewLabReportOfPatient(string EmailId, string TestName) // image, get part is not returning badrequest,en
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
                    if(query!=null)
                    return query.ToList();
                    return null;

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
        public bool ChangePassword(int ID,string Password)
        {
            try
            {
                var doc = context.appUsers.Find(ID);
                if (doc == null)
                    return false;
                else
                {
                    doc.Password = Password;
                    var Rows = context.SaveChanges();
                    if (Rows == 1)
                        return true;
                    return false;
                    /*doc.FirstName = app.FirstName;
                    doc.MiddleName = app.MiddleName;
                    doc.LastName = app.LastName;
                    doc.Gender = app.Gender;
                    doc.PhoneNumber = app.PhoneNumber;
                    doc.Address = app.Address;
                    doc.EmailId = app.EmailId;
                    doc.UserType = app.UserType;
                    doc.Password = app.Password;
                    var Rows = context.SaveChanges();
                    if (Rows == 1)
                        return true;
                    else
                        return false;*/
                }
                

            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("not found", e);

            }
        }

        //Harish
        public bool AddDoctorDetails(DoctorDetails doctorDetails)
        {
            try
            {
                AppUser user = context.appUsers.Find(doctorDetails.DoctorId);
                if(user.UserType=="Doctor")
                {
                    context.DoctorDetails.Add(doctorDetails);
                    int RowsAffected = context.SaveChanges();
                    return RowsAffected == 1;
                }
                return false;
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Adding Details... failed", e);

            }
        }
    }
}
