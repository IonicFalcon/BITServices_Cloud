using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices_WebForms.Models
{
    interface IUser
    {
        bool Login(string enteredPassword);
    }
}
