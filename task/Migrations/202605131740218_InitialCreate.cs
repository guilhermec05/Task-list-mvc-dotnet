namespace task.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.tasks",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    title = c.String(nullable: false, maxLength: 100),
                    description = c.String(maxLength: 500),
                    due_date = c.DateTime(),
                    state = c.Int(nullable: false),
                    user_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);

            CreateTable(
                "public.users",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false, maxLength: 200),
                    email = c.String(nullable: false, maxLength: 200),
                    password = c.String(nullable: false),
                })
                .PrimaryKey(t => t.id);

        }

        public override void Down()
        {
            DropForeignKey("public.tasks", "user_id", "public.users");
            DropIndex("public.tasks", new[] { "user_id" });
            DropTable("public.users");
            DropTable("public.tasks");
        }
    }
}
