namespace MedicalReportBookEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creatednewentitiesandnavigations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorDetails",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        Specialization = c.String(),
                        Qualification = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.AppUsers", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        BloodGroup = c.String(),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.User_Id)
                .ForeignKey("dbo.AppUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetails", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.DoctorDetails", "DoctorId", "dbo.AppUsers");
            DropIndex("dbo.UserDetails", new[] { "User_Id" });
            DropIndex("dbo.DoctorDetails", new[] { "DoctorId" });
            DropTable("dbo.UserDetails");
            DropTable("dbo.DoctorDetails");
        }
    }
}
