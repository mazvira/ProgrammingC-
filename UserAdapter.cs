using System;

namespace Lab1
{
   static class UserAdapter
    {
       internal static User CreateUser(DateTime date)
        {
            try
            {
                return new User(date);
            }
            catch
            {
                return null ;
            }
           
        }
    }
}
