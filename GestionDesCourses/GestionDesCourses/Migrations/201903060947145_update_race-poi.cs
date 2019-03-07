namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_racepoi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pois", "Race_Id", "dbo.Races");
            DropIndex("dbo.Pois", new[] { "Race_Id" });
            CreateTable(
                "dbo.RacePois",
                c => new
                    {
                        Race_Id = c.Int(nullable: false),
                        Poi_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Race_Id, t.Poi_Id })
                .ForeignKey("dbo.Races", t => t.Race_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pois", t => t.Poi_Id, cascadeDelete: true)
                .Index(t => t.Race_Id)
                .Index(t => t.Poi_Id);
            
            DropColumn("dbo.Pois", "Race_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pois", "Race_Id", c => c.Int());
            DropForeignKey("dbo.RacePois", "Poi_Id", "dbo.Pois");
            DropForeignKey("dbo.RacePois", "Race_Id", "dbo.Races");
            DropIndex("dbo.RacePois", new[] { "Poi_Id" });
            DropIndex("dbo.RacePois", new[] { "Race_Id" });
            DropTable("dbo.RacePois");
            CreateIndex("dbo.Pois", "Race_Id");
            AddForeignKey("dbo.Pois", "Race_Id", "dbo.Races", "Id");
        }
    }
}
