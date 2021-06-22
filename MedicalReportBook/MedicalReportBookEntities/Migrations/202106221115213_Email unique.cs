namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Emailunique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "EmailId", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.AppUsers", "PhoneNumber", unique: true);
            CreateIndex("dbo.AppUsers", "EmailId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AppUsers", new[] { "EmailId" });
            DropIndex("dbo.AppUsers", new[] { "PhoneNumber" });
            AlterColumn("dbo.AppUsers", "EmailId", c => c.String(nullable: false));
        }
    }
}
