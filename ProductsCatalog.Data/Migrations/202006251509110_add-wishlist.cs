namespace ProductsCatalog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwishlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WishLists", "ProductId", "dbo.Products");
            DropIndex("dbo.WishLists", new[] { "ProductId" });
            DropIndex("dbo.WishLists", new[] { "UserId" });
            DropTable("dbo.WishLists");
        }
    }
}
