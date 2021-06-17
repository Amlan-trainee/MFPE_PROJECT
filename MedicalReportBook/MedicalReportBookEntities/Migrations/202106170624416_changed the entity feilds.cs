namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtheentityfeilds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConsultancyReports", "Prescription", c => c.String(unicode: false));
            AlterColumn("dbo.LabReportEntities", "LabReport", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LabReportEntities", "LabReport", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.ConsultancyReports", "Prescription", c => c.String(nullable: false, unicode: false));
        }
    }
}
