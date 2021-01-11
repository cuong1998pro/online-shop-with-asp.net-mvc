namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        Detail = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        ParentID = c.Long(),
                        DisplayOrder = c.Int(),
                        SeoTitle = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(nullable: false),
                        ShowOnHome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        CategoryID = c.Long(),
                        Detail = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(nullable: false),
                        TopHot = c.DateTime(),
                        ViewCount = c.Int(),
                        Tags = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ContentTag",
                c => new
                    {
                        ContentID = c.Long(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ContentID, t.TagID });
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Content = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 50),
                        Link = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Target = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ProductID = c.Long(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => new { t.ProductID, t.OrderID });
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(),
                        CustomerID = c.Int(),
                        ShipName = c.String(maxLength: 50),
                        ShipMobile = c.String(maxLength: 50),
                        ShipAddress = c.String(maxLength: 50),
                        ShipEmail = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        ParentID = c.Long(),
                        DisplayOrder = c.Int(),
                        SeoTitle = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(nullable: false),
                        ShowOnHome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 20, unicode: false),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Decimal(precision: 18, scale: 0),
                        PromotionPrice = c.Decimal(precision: 18, scale: 0),
                        IncludedVAT = c.Boolean(nullable: false),
                        Quantity = c.Int(),
                        CategoryID = c.Long(),
                        Detail = c.String(storeType: "ntext"),
                        Warranty = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(nullable: false),
                        TopHot = c.DateTime(),
                        ViewCount = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CategoryName = c.String(),
                        CategoryMetaTitle = c.String(),
                        MetaTitle = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Link = c.String(maxLength: 250),
                        Description = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                        Value = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 32, unicode: false),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        ProvinceID = c.Int(),
                        DistrictID = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Content", "CategoryID", "dbo.Category");
            DropIndex("dbo.Content", new[] { "CategoryID" });
            DropTable("dbo.User");
            DropTable("dbo.Tag");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.Slide");
            DropTable("dbo.ProductViewModels");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.MenuType");
            DropTable("dbo.Menu");
            DropTable("dbo.Footer");
            DropTable("dbo.Feedback");
            DropTable("dbo.ContentTag");
            DropTable("dbo.Contact");
            DropTable("dbo.Content");
            DropTable("dbo.Category");
            DropTable("dbo.About");
        }
    }
}
