using System.Linq;
using task.Context;
using task.Util;

namespace task.DataBase.Seeders
{
    public static class UsersSeeds
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            context.Users.Add(
                new Domain.Models.User
                {
                    Name = "Test",
                    Email = "teste@email.com",
                    Password = PasswordHandler.Hash("12345678")

                }
                );

            context.SaveChanges();

        }
    }
}