using System.Data.Entity;
using task.DataBase.Tables;
using task.Domain.Models;

namespace task.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
           : base("DefaultConnection")
        {
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());

            modelBuilder.Configurations.Add(new TaskMap());

            base.OnModelCreating(modelBuilder);


        }

    }
}