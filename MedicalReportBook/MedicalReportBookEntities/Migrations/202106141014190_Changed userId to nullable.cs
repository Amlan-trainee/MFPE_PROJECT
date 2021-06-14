namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeduserIdtonullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ConsultancyReports", "UserID", "dbo.AppUsers");
            DropIndex("dbo.ConsultancyReports", new[] { "UserID" });
            AlterColumn("dbo.ConsultancyReports", "UserID", c => c.Int());
            CreateIndex("dbo.ConsultancyReports", "UserID");
            AddForeignKey("dbo.ConsultancyReports", "UserID", "dbo.AppUsers", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsultancyReports", "UserID", "dbo.AppUsers");
            DropIndex("dbo.ConsultancyReports", new[] { "UserID" });
            AlterColumn("dbo.ConsultancyReports", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.ConsultancyReports", "UserID");
            AddForeignKey("dbo.ConsultancyReports", "UserID", "dbo.AppUsers", "UserId", cascadeDelete: true);
        }
    }
}
