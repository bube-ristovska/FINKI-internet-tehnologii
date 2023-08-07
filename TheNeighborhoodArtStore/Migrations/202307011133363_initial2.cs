namespace TheNeighborhoodArtStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Products", new[] { "Artist_Id" });
            RenameColumn(table: "dbo.Products", name: "Artist_Id", newName: "ArtistId");
            AlterColumn("dbo.Products", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ArtistId");
            AddForeignKey("dbo.Products", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Products", new[] { "ArtistId" });
            AlterColumn("dbo.Products", "ArtistId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Products", "Artist_Id");
            AddForeignKey("dbo.Products", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
