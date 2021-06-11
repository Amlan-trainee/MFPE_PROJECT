namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasechanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "EmailId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "EmailId", c => c.String());
        }
    }
}
