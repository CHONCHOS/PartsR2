namespace PartsR2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        ResearchReqFile = c.String(),
                        DateResearchAssigned = c.String(),
                        PriorityLevel = c.Int(nullable: false),
                        StatusLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID);
            
            CreateTable(
                "dbo.Quote",
                c => new
                    {
                        QuoteID = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        ContactDate = c.DateTime(nullable: false),
                        ListingService = c.Int(nullable: false),
                        ContactMethod = c.Int(nullable: false),
                        ContactName = c.String(),
                        ContactEmail = c.String(),
                        ContactPhone = c.String(),
                        ContactFax = c.String(),
                        FileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuoteID)
                .ForeignKey("dbo.File", t => t.FileID, cascadeDelete: true)
                .Index(t => t.FileID);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        PartNumber = c.String(nullable: false),
                        Desc = c.String(nullable: false),
                        CondAvail = c.String(),
                        QtyAvail = c.String(),
                        Exchange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutrightPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Certs = c.String(),
                        Remarks = c.String(),
                        JJRemarks = c.String(),
                        IssuePO = c.String(),
                        PONumber = c.String(),
                        QuoteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartID)
                .ForeignKey("dbo.Quote", t => t.QuoteID, cascadeDelete: true)
                .Index(t => t.QuoteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Part", "QuoteID", "dbo.Quote");
            DropForeignKey("dbo.Quote", "FileID", "dbo.File");
            DropIndex("dbo.Part", new[] { "QuoteID" });
            DropIndex("dbo.Quote", new[] { "FileID" });
            DropTable("dbo.Part");
            DropTable("dbo.Quote");
            DropTable("dbo.File");
        }
    }
}
