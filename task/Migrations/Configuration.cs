namespace task.Migrations
{
    using System.Data.Entity.Migrations;
    using task.DataBase.Seeders;

    internal sealed class Configuration : DbMigrationsConfiguration<task.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(task.Context.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data
            //  

            UsersSeeds.Seed(context);
        }
    }
}
