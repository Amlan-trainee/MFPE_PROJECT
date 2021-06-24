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
    public class DoctorService:IDisposable
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
                throw new MedicalReportBookExceptions("Counsultancy Report Error", e);
            }
            catch (Exception e)
            {
                throw new MedicalReportBookExceptions("Unknown error while getting consultancy report", e);
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
                throw new MedicalReportBookExceptions("Lab Report Error", e);
            }
            catch (Exception e)
            {
                throw new MedicalReportBookExceptions("Unknown error while getting lab report", e);
            }
        }
        /// <summary>
        /// This method will allow the doctor to change his password.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="OldPassword"></param>
        /// <param name="NewPassword"></param>
        /// <returns>True is password is changed else returns false.</returns>
        public bool ChangePassword(int ID,string OldPassword,string NewPassword)
        {
            try
            {
                var obj = context.appUsers.Find(ID);
                if(obj!=null)
                {
                    if (obj.Password == OldPassword)
                    {
                        obj.Password = NewPassword;
                        context.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                }
                return false;
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Error in Changing Password", e);
            }
            catch (Exception e)
            {
                throw new MedicalReportBookExceptions("Unknown error while Changing Password", e);
            }
        }

        /// <summary>
        /// This method will allow the doctor to add additional details.
        /// </summary>
        /// <param name="doctorDetails"></param>
        /// <returns> Returns true on sucessful execution else returns false</returns>
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
                throw new MedicalReportBookExceptions("Adding Doctor Details... failed", e);
            }
            catch (Exception e)
            {
                throw new MedicalReportBookExceptions("Unknown error while Adding Doctor", e);
            }
        }
    }
}
