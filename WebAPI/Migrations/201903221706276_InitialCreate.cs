namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Common.CountryCodes",
                c => new
                    {
                        CountryCodeId = c.Int(nullable: false, identity: true),
                        CountryAbbr = c.String(nullable: false, maxLength: 3),
                        CountryName = c.String(nullable: false, maxLength: 256),
                        LoadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CountryCodeId)
                .Index(t => t.CountryAbbr, unique: true);
            
            CreateTable(
                "WEBAPP2.StateCodes",
                c => new
                    {
                        StateCodeId = c.Int(nullable: false, identity: true),
                        StateAbbr = c.String(nullable: false, maxLength: 2),
                        StateName = c.String(nullable: false, maxLength: 128),
                        LoadDate = c.DateTime(nullable: false),
                        CountryCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateCodeId)
                .ForeignKey("Common.CountryCodes", t => t.CountryCodeId, cascadeDelete: true)
                .Index(t => t.StateAbbr)
                .Index(t => t.CountryCodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("WEBAPP2.StateCodes", "CountryCodeId", "Common.CountryCodes");
            DropIndex("WEBAPP2.StateCodes", new[] { "CountryCodeId" });
            DropIndex("WEBAPP2.StateCodes", new[] { "StateAbbr" });
            DropIndex("Common.CountryCodes", new[] { "CountryAbbr" });
            DropTable("WEBAPP2.StateCodes");
            DropTable("Common.CountryCodes");
        }
    }
}
