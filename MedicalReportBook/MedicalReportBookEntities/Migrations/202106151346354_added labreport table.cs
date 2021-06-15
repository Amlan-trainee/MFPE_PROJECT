namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlabreporttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LabReportEntities",
                c => new
                    {
                        Lr_Id = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(nullable: false, maxLength: 30),
                        LabName = c.String(nullable: false, maxLength: 30),
                        DateofTest = c.DateTime(nullable: false),
                        TestName = c.String(nullable: false, maxLength: 30),
                        LabReport = c.String(nullable: false, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        UID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Lr_Id)
                .ForeignKey("dbo.AppUsers", t => t.UID, cascadeDelete: true)
                .Index(t => t.UID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LabReportEntities", "UID", "dbo.AppUsers");
            DropIndex("dbo.LabReportEntities", new[] { "UID" });
            DropTable("dbo.LabReportEntities");
        }
    }
}
