namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaccinetableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaccineDetails",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        VaccineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AppUsers", t => t.UserID)
                .ForeignKey("dbo.Vaccines", t => t.VaccineID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.VaccineID);
            
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        VaccineId = c.Int(nullable: false, identity: true),
                        VaccineName = c.String(),
                    })
                .PrimaryKey(t => t.VaccineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VaccineDetails", "VaccineID", "dbo.Vaccines");
            DropForeignKey("dbo.VaccineDetails", "UserID", "dbo.AppUsers");
            DropIndex("dbo.VaccineDetails", new[] { "VaccineID" });
            DropIndex("dbo.VaccineDetails", new[] { "UserID" });
            DropTable("dbo.Vaccines");
            DropTable("dbo.VaccineDetails");
        }
    }
}
