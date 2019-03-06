namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mariam3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inscriptions", "RaceTitle", c => c.String());
            AddColumn("dbo.Inscriptions", "RaceStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Inscriptions", "RaceEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inscriptions", "RaceEnd");
            DropColumn("dbo.Inscriptions", "RaceStart");
            DropColumn("dbo.Inscriptions", "RaceTitle");
        }
    }
}
