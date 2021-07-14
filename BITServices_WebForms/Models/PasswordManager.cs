using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices_WebForms.Models
{
    class PasswordManager
    {
        public static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }

        public static string HashPassword(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }

        public static bool VerifyPassword(string knownHash, string unknownHash)
        {
            return BCrypt.Net.BCrypt.Verify(knownHash, unknownHash);
        }
    }
}
