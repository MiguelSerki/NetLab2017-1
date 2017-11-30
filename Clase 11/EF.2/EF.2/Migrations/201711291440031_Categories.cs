namespace EF._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeesCategories",
                c => new
                    {
                        Id1 = c.Int(nullable: false),
                        Id2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id1, t.Id2 })
                .ForeignKey("dbo.Employees", t => t.Id1, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Id2, cascadeDelete: true)
                .Index(t => t.Id1)
                .Index(t => t.Id2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeesCategories", "Id2", "dbo.Categories");
            DropForeignKey("dbo.EmployeesCategories", "Id1", "dbo.Employees");
            DropIndex("dbo.EmployeesCategories", new[] { "Id2" });
            DropIndex("dbo.EmployeesCategories", new[] { "Id1" });
            DropTable("dbo.EmployeesCategories");
            DropTable("dbo.Categories");
        }
    }
}
