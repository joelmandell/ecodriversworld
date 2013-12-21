namespace DataNissen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PassHash = c.String(),
                        Confirmed = c.String(),
                        Banned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(),
                        ForumTag = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PostFoot = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Properties");
            DropTable("dbo.Members");
        }
    }
}
