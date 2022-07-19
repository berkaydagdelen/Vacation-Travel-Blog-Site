namespace TravelTripProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteBlogIDcolumnInRehbersTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rehbers", "BlogID", "dbo.Blogs");
            DropIndex("dbo.Rehbers", new[] { "BlogID" });
            DropColumn("dbo.Rehbers", "BlogID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rehbers", "BlogID", c => c.Int(nullable: false));
            CreateIndex("dbo.Rehbers", "BlogID");
            AddForeignKey("dbo.Rehbers", "BlogID", "dbo.Blogs", "ID", cascadeDelete: true);
        }
    }
}
