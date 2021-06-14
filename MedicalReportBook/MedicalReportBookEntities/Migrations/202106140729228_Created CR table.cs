namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedCRtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsultancyReports",
                c => new
                    {
                        CR_Id = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(nullable: false, maxLength: 30),
                        DateofConsultancy = c.DateTime(nullable: false),
                        ClinicName = c.String(nullable: false, maxLength: 30),
                        DiseaseName = c.String(nullable: false, maxLength: 30),
                        Prescription = c.String(nullable: false, unicode: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CR_Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsultancyReports", "UserId", "dbo.AppUsers");
            DropIndex("dbo.ConsultancyReports", new[] { "UserId" });
            DropTable("dbo.ConsultancyReports");
        }
    }
}
