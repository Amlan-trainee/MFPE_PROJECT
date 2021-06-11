using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalReportBookEntities;
using MedicalReportBookEntities.Entities;


namespace MedicalReportBookBLL
{
    public class AppUserService : IDisposable
    {
        private readonly MedicalReportBookModel context;

        public AppUserService()
        {
            context = new MedicalReportBookModel();
        }
        public void Dispose()
        {
            context.Dispose();

        }

        public bool AddUser(AppUser appUser)
        {
            try {
                context.appUsers.Add(appUser);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;
            }
            catch(DbException e)
            {
                throw new MedicalReportBookExceptions("Registration failed",e);

            }
            catch(Exception e)
            {
                throw new MedicalReportBookExceptions("Unknown Data", e);

            }
        }
        public bool Login(string EmailId,string password)
        {
            try {
                var obj = context.appUsers.Find(EmailId);
                if (obj.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Login failed", e);

            }
            catch (Exception e)
            {
                throw new MedicalReportBookExceptions("Unknown data,try again", e);

            }



        }


    }
}
