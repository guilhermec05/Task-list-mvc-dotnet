using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using task.Domain.Models;

namespace task.DataBase.Tables
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {

            ToTable("public.users");

            HasKey(x => x.Id);


            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("name").HasMaxLength(200).IsRequired();

            Property(x => x.Email).HasColumnName("email").HasMaxLength(200).IsRequired();

            Property(x => x.Password).HasColumnName("password").IsRequired();

            HasMany(x => x.Tasks).WithRequired(x => x.User).HasForeignKey(x => x.UserId);

        }
    }
}