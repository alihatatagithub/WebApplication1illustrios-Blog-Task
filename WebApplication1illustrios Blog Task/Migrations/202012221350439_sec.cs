namespace WebApplication1illustrios_Blog_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sec : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.AspNetUsers", "Post_Id", "dbo.Posts");
            DropIndex("dbo.AspNetUsers", new[] { "BlogId" });
            DropIndex("dbo.AspNetUsers", new[] { "Post_Id" });
            DropColumn("dbo.AspNetUsers", "BlogId");
            DropColumn("dbo.AspNetUsers", "Post_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Post_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "BlogId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Post_Id");
            CreateIndex("dbo.AspNetUsers", "BlogId");
            AddForeignKey("dbo.AspNetUsers", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.AspNetUsers", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
        }
    }
}
