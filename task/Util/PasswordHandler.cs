using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task.Util
{
    public static class PasswordHandler
    {
        public static string Hash(string password)
        {
            
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool CheckPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}