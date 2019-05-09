namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        Genreid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Genres", t => t.Genreid, cascadeDelete: true)
                .Index(t => t.Genreid);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genreid", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genreid" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
