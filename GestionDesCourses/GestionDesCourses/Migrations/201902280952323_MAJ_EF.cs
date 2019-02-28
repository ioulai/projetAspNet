namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAJ_EF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pois",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Race_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.Race_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pois", "Race_Id", "dbo.Races");
            DropIndex("dbo.Pois", new[] { "Race_Id" });
            DropTable("dbo.Pois");
        }
    }
}
