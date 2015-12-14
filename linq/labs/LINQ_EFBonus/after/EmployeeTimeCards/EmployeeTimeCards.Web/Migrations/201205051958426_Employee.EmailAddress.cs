namespace EmployeeTimeCards.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeEmailAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("Employees", "EmailAddress", c => c.String(maxLength: 40));
            CreateIndex("Employees", "EmailAddress", unique:true);
            Sql(@"UPDATE Employees  
                   SET EmailAddress = FirstName + '.' + LastName + '@otc.com'");
        }
        
        public override void Down()
        {            
            DropColumn("Employees", "EmailAddress");
        }
    }
}
