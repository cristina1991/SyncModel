namespace FileMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Id", "dbo.UserProfile");
            DropIndex("dbo.Files", new[] { "Id" });
            RenameColumn(table: "dbo.Files", name: "Id", newName: "UserId");
            AlterColumn("dbo.Files", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Files", new[] { "Id" });
            AddPrimaryKey("dbo.Files", "Id");
            AddForeignKey("dbo.Files", "UserId", "dbo.UserProfile", "UserId", cascadeDelete: true);
            CreateIndex("dbo.Files", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Files", new[] { "UserId" });
            DropForeignKey("dbo.Files", "UserId", "dbo.UserProfile");
            DropPrimaryKey("dbo.Files", new[] { "Id" });
            AddPrimaryKey("dbo.Files", "Id");
            AlterColumn("dbo.Files", "Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Files", name: "UserId", newName: "Id");
            CreateIndex("dbo.Files", "Id");
            AddForeignKey("dbo.Files", "Id", "dbo.UserProfile", "UserId");
        }
    }
}
