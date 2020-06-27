namespace ProductsCatalog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addslideshow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slideshows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        SubTitle = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Slideshows");
        }
    }
}
