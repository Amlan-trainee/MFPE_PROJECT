namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultancyReports", "UserID", "dbo.AppUsers");
            DropIndex("dbo.ConsultancyReports", new[] { "UserID" });
            AlterColumn("dbo.ConsultancyReports", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ConsultancyReports", "UserId");
            AddForeignKey("dbo.ConsultancyReports", "UserId", "dbo.AppUsers", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsultancyReports", "UserId", "dbo.AppUsers");
            DropIndex("dbo.ConsultancyReports", new[] { "UserId" });
            AlterColumn("dbo.ConsultancyReports", "UserId", c => c.Int());
            CreateIndex("dbo.ConsultancyReports", "UserID");
            AddForeignKey("dbo.ConsultancyReports", "UserID", "dbo.AppUsers", "UserId");
        }
    }
}
