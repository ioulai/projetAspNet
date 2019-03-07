namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_racecategoryoneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Races", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Races", new[] { "Category_Id" });
            AlterColumn("dbo.Races", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Races", "Category_Id");
            AddForeignKey("dbo.Races", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Races", new[] { "Category_Id" });
            AlterColumn("dbo.Races", "Category_Id", c => c.Int());
            CreateIndex("dbo.Races", "Category_Id");
            AddForeignKey("dbo.Races", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
