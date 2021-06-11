namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasechangedagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "UserType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "UserType", c => c.String());
        }
    }
}
