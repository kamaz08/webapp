namespace WebApi.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tests", newName: "Test");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Test", newName: "Tests");
        }
    }
}
