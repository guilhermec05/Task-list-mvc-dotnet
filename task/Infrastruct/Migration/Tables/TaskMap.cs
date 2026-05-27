using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using task.Domain.Models;

namespace task.Infrastruct.Migration.Tables
{
    public class TaskMap : EntityTypeConfiguration<Tasks>
    {

        public TaskMap()
        {
            ToTable("public.tasks");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Title).HasColumnName("title").HasMaxLength(100).IsRequired();


            Property(x => x.Description).HasColumnName("description").HasColumnType("Text").IsOptional();

            Property(x => x.DueDate).HasColumnName("due_date").IsOptional();

            Property(x => x.State).HasColumnName("state").IsRequired();

            Property(x => x.UserId)
                .HasColumnName("user_id");

            HasRequired(x => x.User)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.UserId);
        }

    }
}