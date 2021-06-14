namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConsultancyReports", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConsultancyReports", "IsActive");
        }
    }
}
