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
        private readonly MedicalReportBookContext context;

        public AppUserService()
        {
            context = new MedicalReportBookContext();
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
            
        }
        public IQueryable Login(string EmailId,string Password)
        {
            try
            {
                var query = from user in context.appUsers
                            where user.EmailId == EmailId && user.Password == Password
                            select user.UserType.FirstOrDefault();
                return query;
                //var obj= context.appUsers.Any(user => user.EmailId.Equals(EmailId) && user.Password.Equals(Password));
                

            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Login Error", e);

            }

        }


    }
}
