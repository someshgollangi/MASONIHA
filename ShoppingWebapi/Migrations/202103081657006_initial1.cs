namespace ShoppingWebapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User_tbl", "role_Tbl_RoleId", "dbo.Role_tbl");
            DropIndex("dbo.User_tbl", new[] { "role_Tbl_RoleId" });
            RenameColumn(table: "dbo.User_tbl", name: "role_Tbl_RoleId", newName: "RoleId");
            AlterColumn("dbo.User_tbl", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.User_tbl", "RoleId");
            AddForeignKey("dbo.User_tbl", "RoleId", "dbo.Role_tbl", "RoleId", cascadeDelete: true);
            DropColumn("dbo.User_tbl", "RoleFkId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_tbl", "RoleFkId", c => c.Int(nullable: false));
            DropForeignKey("dbo.User_tbl", "RoleId", "dbo.Role_tbl");
            DropIndex("dbo.User_tbl", new[] { "RoleId" });
            AlterColumn("dbo.User_tbl", "RoleId", c => c.Int());
            RenameColumn(table: "dbo.User_tbl", name: "RoleId", newName: "role_Tbl_RoleId");
            CreateIndex("dbo.User_tbl", "role_Tbl_RoleId");
            AddForeignKey("dbo.User_tbl", "role_Tbl_RoleId", "dbo.Role_tbl", "RoleId");
        }
    }
}
