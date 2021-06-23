namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaccinetabledeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VaccineDetails", "UserID", "dbo.AppUsers");
            DropForeignKey("dbo.VaccineDetails", "VaccineID", "dbo.Vaccines");
            DropIndex("dbo.VaccineDetails", new[] { "UserID" });
            DropIndex("dbo.VaccineDetails", new[] { "VaccineID" });
            DropTable("dbo.VaccineDetails");
            DropTable("dbo.Vaccines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        VaccineId = c.Int(nullable: false, identity: true),
                        VaccineName = c.String(),
                    })
                .PrimaryKey(t => t.VaccineId);
            
            CreateTable(
                "dbo.VaccineDetails",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        VaccineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateIndex("dbo.VaccineDetails", "VaccineID");
            CreateIndex("dbo.VaccineDetails", "UserID");
            AddForeignKey("dbo.VaccineDetails", "VaccineID", "dbo.Vaccines", "VaccineId", cascadeDelete: true);
            AddForeignKey("dbo.VaccineDetails", "UserID", "dbo.AppUsers", "UserId");
        }
    }
}
