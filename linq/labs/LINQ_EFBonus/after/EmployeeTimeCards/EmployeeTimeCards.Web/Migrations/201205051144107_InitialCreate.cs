namespace EmployeeTimeCards.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 80),
                        LastName = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TimeCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hours = c.Int(nullable: false),
                        Period_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PayPeriods", t => t.Period_Id)
                .ForeignKey("Employees", t => t.Employee_Id)
                .Index(t => t.Period_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "PayPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("TimeCards", new[] { "Employee_Id" });
            DropIndex("TimeCards", new[] { "Period_Id" });
            DropForeignKey("TimeCards", "Employee_Id", "Employees");
            DropForeignKey("TimeCards", "Period_Id", "PayPeriods");
            DropTable("PayPeriods");
            DropTable("TimeCards");
            DropTable("Employees");
        }
    }
}
