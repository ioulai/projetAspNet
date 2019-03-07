namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_racepoimanyToMany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "Poi_Id", c => c.Int());
            CreateIndex("dbo.Races", "Poi_Id");
            AddForeignKey("dbo.Races", "Poi_Id", "dbo.Pois", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "Poi_Id", "dbo.Pois");
            DropIndex("dbo.Races", new[] { "Poi_Id" });
            DropColumn("dbo.Races", "Poi_Id");
        }
    }
}
