using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using task.DataBase.Tables;
using task.Models;

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