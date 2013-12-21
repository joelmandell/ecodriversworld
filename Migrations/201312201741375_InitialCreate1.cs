namespace DataNissen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Email", c => c.String());
            AddColumn("dbo.Members", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Salt");
            DropColumn("dbo.Members", "Email");
        }
    }
}
