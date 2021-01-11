namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkcontentcategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Content", "CategoryID", "dbo.Category");
            DropIndex("dbo.Content", new[] { "CategoryID" });
            AlterColumn("dbo.Content", "CategoryID", c => c.Long(nullable: false));
            CreateIndex("dbo.Content", "CategoryID");
            AddForeignKey("dbo.Content", "CategoryID", "dbo.Category", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Content", "CategoryID", "dbo.Category");
            DropIndex("dbo.Content", new[] { "CategoryID" });
            AlterColumn("dbo.Content", "CategoryID", c => c.Long());
            CreateIndex("dbo.Content", "CategoryID");
            AddForeignKey("dbo.Content", "CategoryID", "dbo.Category", "ID");
        }
    }
}
