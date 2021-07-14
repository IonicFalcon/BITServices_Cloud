using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BITServices_WebForms.Models
{
    abstract class Person : IUser
    {
        public string Street {get; set;}
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicData { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public bool Login(string enteredPassword)
        {
            string unknownHash = enteredPassword + PasswordSalt;

            return PasswordManager.VerifyPassword(unknownHash, PasswordHash);  //Check against known hash for password
        }
    }
}
