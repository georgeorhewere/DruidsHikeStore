using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.DB
{
    public class StoreDbInitializer
    {


        public static void Initialize(StoreDBContext context)
        {
            context.Database.EnsureCreated();
        }


    }
}
