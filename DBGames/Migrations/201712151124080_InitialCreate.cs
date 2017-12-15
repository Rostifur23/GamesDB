namespace DBGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(),
                        HQ = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        EngineId = c.Int(nullable: false, identity: true),
                        EngineName = c.String(),
                        WrittenIn = c.String(),
                    })
                .PrimaryKey(t => t.EngineId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        Mode = c.String(),
                        DeveloperId = c.Int(),
                        EngineId = c.Int(),
                        PlatformId = c.Int(),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Developers", t => t.DeveloperId)
                .ForeignKey("dbo.Engines", t => t.EngineId)
                .ForeignKey("dbo.Platforms", t => t.PlatformId)
                .Index(t => t.DeveloperId)
                .Index(t => t.EngineId)
                .Index(t => t.PlatformId);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        PlatformId = c.Int(nullable: false, identity: true),
                        PlatformName = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.PlatformId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.Games", "EngineId", "dbo.Engines");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Games", new[] { "PlatformId" });
            DropIndex("dbo.Games", new[] { "EngineId" });
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropTable("dbo.Platforms");
            DropTable("dbo.Games");
            DropTable("dbo.Engines");
            DropTable("dbo.Developers");
        }
    }
}
