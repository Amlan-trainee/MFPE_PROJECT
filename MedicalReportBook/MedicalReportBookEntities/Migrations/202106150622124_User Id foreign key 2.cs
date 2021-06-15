namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdforeignkey2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ConsultancyReports", name: "UserId", newName: "UId");
            RenameIndex(table: "dbo.ConsultancyReports", name: "IX_UserId", newName: "IX_UId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ConsultancyReports", name: "IX_UId", newName: "IX_UserId");
            RenameColumn(table: "dbo.ConsultancyReports", name: "UId", newName: "UserId");
        }
    }
}
