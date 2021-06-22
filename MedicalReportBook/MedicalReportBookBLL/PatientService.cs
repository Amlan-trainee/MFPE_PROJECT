﻿using MedicalReportBookEntities;
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
    
    /// <summary>
  /// PatientService to interact with MedicalReportBookModel database and do CRUD operation
  /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public bool AddUserDetails(UserDetails userDetails)
        {
            try
            {
                context.UserDetails.Add(userDetails);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Adding Details... failed", e);
            }
        }
        /// <summary>
        /// AddConsultancyReport -method to add prescriptions to the database along with the required feilds
        /// </summary>
        /// <param name="consultancyReport"></param>
        /// <returns> returns true in case of sucessful adddition of data to database else return false</returns>
        public bool AddConsultancyReport(ConsultancyReport consultancyReport)
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
        /// <summary>
        /// ViewConsultancyReportByDiseaseName -method to view the consultancy  report of a particular user based on disease name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="DiseaseName"></param>
        /// <returns>List of consultancy report on sucessful execution else returns null</returns>
        public List<ConsultancyReport> ViewConsultancyReportByDiseaseName(int id ,string DiseaseName) //give id (input it) include ,,image 
        {
            try 
            {
                var query = from obj in context.ConsultancyReports.Include(user => user.User)
                             where obj.DiseaseName == DiseaseName && obj.UId==id
                            select obj;
                if(query!=null)
                return query.ToList();
                return null;
            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Not Found", e);

            }


        }
        /// <summary>
        /// AddLabReport -method to add prescriptions to the database along with the required feilds
        /// </summary>
        /// <param name="labReportEntity"></param>
        /// <returns> returns true in case of sucessful adddition of data to database else return false</returns>
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
        /// <summary>
        /// ViewLabReportByTestName -method to view the lab  report of a particular user based on test name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TestName"></param>
        /// <returns>return list of lab reports on sucessful execution esle returns null</returns>
        public List<LabReportEntity> ViewLabReportByTestName(int id, string TestName) //give id (input it) include ,,image 
        {
            try
            {
                var query = from obj in context.LabReportEntities.Include(user => user.User)
                            where obj.TestName == TestName && obj.UID == id
                            select obj;
                if(query!=null)
                return query.ToList();
                return null;
            }

            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("not found", e);

            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TestName"></param>
        /// <returns></returns>
        public bool DeleteLabReportByTestName(int id,string TestName,int Lr_Id)
        {
            try
            {
                LabReportEntity labReportEntity = (from obj in context.LabReportEntities.Include(user => user.User)
                            where obj.TestName == TestName && obj.UID == id && obj.Lr_Id==Lr_Id
                            select obj).FirstOrDefault();
                context.LabReportEntities.Remove(labReportEntity);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Deleting prescription... failed", e);

            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="DiseaseName"></param>
       /// <returns></returns>
        public bool DeleteConsultancyReportByDiseaseName(int id, string DiseaseName,int CR_Id)
        {
            try
            {
                ConsultancyReport consultancyReport = (from obj in context.ConsultancyReports.Include(user => user.User)
                                                   where obj.DiseaseName == DiseaseName && obj.UId == id && obj.CR_Id==CR_Id
                                                   select obj).FirstOrDefault();
                context.ConsultancyReports.Remove(consultancyReport);
                int RowsAffected = context.SaveChanges();
                return RowsAffected == 1;
            }
            catch (DbException e)
            {
                throw new MedicalReportBookExceptions("Deleting prescription... failed", e);

            }
        }
        public bool AccessPermissionForConsultancyReport(int CR_Id)
        {
            var item = context.ConsultancyReports.Find(CR_Id);
            if (item == null)
                return false;
            else {
                if (item.IsActive == true)
                {
                    item.IsActive = false;
                    context.SaveChanges();
                    return true;
                }
                  
                else
                {
                    item.IsActive = true;
                    context.SaveChanges();
                    return true;
                }
            }
            
        }
        public bool AccessPermissionForLabReport(int Lr_Id)
        {
            var item = context.LabReportEntities.Find(Lr_Id);
            if (item == null)
                return false;
            else 
            {
                if (item.IsActive == true)
                { item.IsActive = false;
                    context.SaveChanges();
                    return true;
                }

                else
                {
                    item.IsActive = true;
                    context.SaveChanges();
                    return true;
                }
                   
            }
         
        }
    }
}
