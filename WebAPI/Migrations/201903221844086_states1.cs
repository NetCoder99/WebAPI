namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class states1 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "WEBAPP2.StateCodes", newSchema: "Common");
        }
        
        public override void Down()
        {
            MoveTable(name: "Common.StateCodes", newSchema: "WEBAPP2");
        }
    }
}
