namespace EF._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Miguel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Supervisor_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Supervisor_Id");
            AddForeignKey("dbo.Employees", "Supervisor_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Supervisor_Id", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Supervisor_Id" });
            DropColumn("dbo.Employees", "Supervisor_Id");
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
