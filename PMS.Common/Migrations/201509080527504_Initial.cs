namespace PMS.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDemands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        PublisherId = c.Guid(nullable: false),
                        BookId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DemandDate = c.DateTime(nullable: false),
                        BookName = c.String(),
                        PublishYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        University = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PostCode = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookDemands", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.BookDemands", "MemberId", "dbo.Member");
            DropIndex("dbo.BookDemands", new[] { "PublisherId" });
            DropIndex("dbo.BookDemands", new[] { "MemberId" });
            DropTable("dbo.Publisher");
            DropTable("dbo.Member");
            DropTable("dbo.BookDemands");
        }
    }
}
