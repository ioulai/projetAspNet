namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mariam2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inscriptions", "IdentityModelId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inscriptions", "IdentityModelId", c => c.Int(nullable: false));
        }
    }
}
