using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
   static class UserAdapter
    {
       internal static User CreateUser(DateTime date)
        {
            return new User(date); // try catch in catch return 0;
        }
    }
}
