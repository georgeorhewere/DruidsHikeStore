using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public class StaticStoreDB
    {


        public static List<User> GetUsers()
        {
            return new List<User>() {
                  new StoreDB.User("Kenny", "Rogers", "kennyrg@gmail.com"),
                new StoreDB.User("Barry", "White", "barryr@gmail.com"),
                new StoreDB.User("Jane", "Fonda", "janefonda@gmail.com"),
                new StoreDB.User("Sam", "Etto", "sametto@gmail.com")
                , new StoreDB.User("Adam", "Sandler", "adamsandler@gmail.com")
                , new StoreDB.User("Olivia", "stone", "oliviastone@gmail.com")
            };
        }
    }

}
