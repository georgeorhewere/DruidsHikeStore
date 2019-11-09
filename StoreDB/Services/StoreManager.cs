using System;
using System.Collections.Generic;
using System.Text;
using StoreDB.Models;
using StoreDB.Repository;
using StoreDB.Services;

namespace StoreDB
{
    public class StoreManager : IStoreManager
    {
        private IDataRepository<User> userManager;
        private IDataRepository<Product> productManager;

        public StoreManager(StoreDB.DB.StoreDBContext context)
        {
            this.userManager = new UserManager(context);
            this.productManager = new ProductManager(context);                
        }

        public IDataRepository<User> UserManager { get => this.userManager; set => this.userManager = value; }
        public IDataRepository<Product> ProductManager { get => this.productManager; set => this.productManager = value; }




    }
}
