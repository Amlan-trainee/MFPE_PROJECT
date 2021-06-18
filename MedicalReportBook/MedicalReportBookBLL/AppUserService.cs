﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalReportBookEntities;
using MedicalReportBookEntities.Entities;


namespace MedicalReportBookBLL
{ 
     /// <summary>
     /// AppUserService to interact with MedicalReportBookModel database and do CRUD operation
    /// </summary>
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
        /// <summary>
        /// AddUser method to Add User Details during the time of registrating the user to database.
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns>true if the user details is added to database else returns false</returns>
        public bool AddUser(AppUser appUser)
        {
            try {
                
                context.appUsers.Add(appUser);
                int RowsAffected = context.SaveChanges();
                if(RowsAffected==1)
                return RowsAffected == 1;
                return false;
            }
            catch(DbException e)
            {
                throw new MedicalReportBookExceptions("Registration failed",e);

            }
            
        }
        /// <summary>
        /// Login method to check the required credentials of user and if true logging them into their account
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="Password"></param>
        /// <param name="id"></param>
        /// <returns>UserType and id if the login operation is sucessful else returns null for usertype and 0 for id</returns>
        public string Login(string EmailId,string Password,out int id)
        {
            try
            {
                var query = (from user in context.appUsers
                             where user.EmailId == EmailId && user.Password == Password
                             select user).FirstOrDefault();
                if (query != null)
                {
                    id = query.UserId;
                    return query.UserType;
                }
                else
                {
                    id = 0;
                    return null;
                }
                
                // var obj= context.appUsers.Any(user => user.EmailId.Equals(EmailId) && user.Password.Equals(Password));
               // return obj;

            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Login Error", e);

            }

        }

        //Harish
        public bool DeleteDoctor(string EmailId)
        {
            try
            {
                AppUser query = (from user in context.appUsers
                                 where user.EmailId == EmailId
                                 select user).FirstOrDefault();
                context.appUsers.Remove(query);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Deleting Doctor... failed", e);

            }
        }
    }
}
