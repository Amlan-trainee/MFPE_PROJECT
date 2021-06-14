namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ConsultancyReports", new[] { "UserId" });
            CreateIndex("dbo.ConsultancyReports", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ConsultancyReports", new[] { "UserID" });
            CreateIndex("dbo.ConsultancyReports", "UserId");
        }
    }
}
