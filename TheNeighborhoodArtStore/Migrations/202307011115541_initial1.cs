namespace TheNeighborhoodArtStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "TypeOfProduct_Id", "dbo.TypeOfProducts");
            DropIndex("dbo.Products", new[] { "TypeOfProduct_Id" });
            DropColumn("dbo.Products", "TypeOfProduct_Id");
            DropTable("dbo.TypeOfProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypeOfProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "TypeOfProduct_Id", c => c.Int());
            CreateIndex("dbo.Products", "TypeOfProduct_Id");
            AddForeignKey("dbo.Products", "TypeOfProduct_Id", "dbo.TypeOfProducts", "Id");
        }
    }
}
