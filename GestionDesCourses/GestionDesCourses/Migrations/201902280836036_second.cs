namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEnd = c.DateTime(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        Title = c.String(),
                        ZipCode = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        IdentityModelId = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        TypeInscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscriptions", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Races", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Inscriptions", new[] { "RaceId" });
            DropIndex("dbo.Races", new[] { "Category_Id" });
            DropTable("dbo.Inscriptions");
            DropTable("dbo.Races");
        }
    }
}
