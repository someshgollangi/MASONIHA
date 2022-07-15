namespace ShoppingWebapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderModel = c.String(),
                        OrderDiscount = c.Int(nullable: false),
                        OrderPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Productid = c.Int(nullable: false, identity: true),
                        Productname = c.String(),
                        Productimage = c.String(),
                    })
                .PrimaryKey(t => t.Productid);
            
            CreateTable(
                "dbo.Role_tbl",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemModel = c.String(),
                        ItemDiscount = c.Int(nullable: false),
                        ItemPrice = c.Int(nullable: false),
                        Specification = c.String(),
                        Iimage = c.String(),
                        Productid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: true)
                .Index(t => t.Productid);
            
            CreateTable(
                "dbo.User_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        RoleFkId = c.Int(nullable: false),
                        role_Tbl_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role_tbl", t => t.role_Tbl_RoleId)
                .Index(t => t.role_Tbl_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_tbl", "role_Tbl_RoleId", "dbo.Role_tbl");
            DropForeignKey("dbo.SubCategories", "Productid", "dbo.Products");
            DropIndex("dbo.User_tbl", new[] { "role_Tbl_RoleId" });
            DropIndex("dbo.SubCategories", new[] { "Productid" });
            DropTable("dbo.User_tbl");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Role_tbl");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
