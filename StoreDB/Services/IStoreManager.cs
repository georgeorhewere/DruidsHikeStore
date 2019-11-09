using StoreDB.Models;
using StoreDB.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public interface IStoreManager
    {

       IDataRepository<User> UserManager { set; get; }
      IDataRepository<Product> ProductManager { set; get; }


    }
}
