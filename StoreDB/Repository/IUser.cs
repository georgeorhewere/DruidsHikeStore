using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Repository
{
   public interface IUser : IDataRepository<User>
    {
        
        User FindUser(int userId);   
        List<User> ListUsersBy();
    }
}
