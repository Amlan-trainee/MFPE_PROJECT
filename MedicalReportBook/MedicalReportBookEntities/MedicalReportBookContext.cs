using System;
using System.Data.Entity;
using System.Linq;
using MedicalReportBookEntities.Entities;

namespace MedicalReportBookEntities
{
    public class MedicalReportBookContext : DbContext
    {
        
        public MedicalReportBookContext()
            : base("name=MedicalReportBookModel")
        {
        }
        public DbSet<AppUser> appUsers { get; set; }

      public DbSet<ConsultancyReport> ConsultancyReports { get; set; }
        public DbSet<LabReportEntity> LabReportEntities { get; set; }
    }

   
}