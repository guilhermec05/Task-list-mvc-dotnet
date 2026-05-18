namespace task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetasktable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.tasks", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("public.tasks", "description", c => c.String(maxLength: 500));
        }
    }
}
