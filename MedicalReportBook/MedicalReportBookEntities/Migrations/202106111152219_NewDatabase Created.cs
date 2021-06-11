namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabaseCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        MiddleName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        Gender = c.String(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        Address = c.String(),
                        EmailId = c.String(),
                        UserType = c.String(),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppUsers");
        }
    }
}
