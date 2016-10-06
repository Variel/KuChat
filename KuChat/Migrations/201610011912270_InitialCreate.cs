namespace KuChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAtUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAtUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AccountId = c.Guid(nullable: false),
                        CreatedAtUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AccountChannels",
                c => new
                    {
                        Account_Id = c.Guid(nullable: false),
                        Channel_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Account_Id, t.Channel_Id })
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .ForeignKey("dbo.Channels", t => t.Channel_Id, cascadeDelete: true)
                .Index(t => t.Account_Id)
                .Index(t => t.Channel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AccountChannels", "Channel_Id", "dbo.Channels");
            DropForeignKey("dbo.AccountChannels", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.AccountChannels", new[] { "Channel_Id" });
            DropIndex("dbo.AccountChannels", new[] { "Account_Id" });
            DropIndex("dbo.Connections", new[] { "AccountId" });
            DropTable("dbo.AccountChannels");
            DropTable("dbo.Connections");
            DropTable("dbo.Channels");
            DropTable("dbo.Accounts");
        }
    }
}
