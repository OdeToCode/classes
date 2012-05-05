namespace EmployeeTimeCards.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class HireDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("Employees", "HireDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Employees", "HireDate");
        }
    }
}
